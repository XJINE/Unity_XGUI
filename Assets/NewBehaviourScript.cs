using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

[AttributeUsage(AttributeTargets.Field)]
public class SyncVar_Attribute : Attribute { }

public struct LongWrapper
{
    public long value;
    public LongWrapper(long value)
    {
        this.value = value;
    }
}

public class SyncListLongWrapper : SyncListStruct<LongWrapper>
{
}

public class FieldInfoAndObject
{
    public FieldInfo field;
    public object obj;

    public FieldInfoAndObject(FieldInfo field, object obj)
    {
        this.field = field;
        this.obj = obj;
    }
}

public class SyncVarLimitWorkaround : NetworkBehaviour
{
    List<FieldInfoAndObject> stringFields = new List<FieldInfoAndObject>();
    SyncListString strings = new SyncListString();

    List<FieldInfoAndObject> floatFields = new List<FieldInfoAndObject>();
    SyncListFloat floats = new SyncListFloat();

    List<FieldInfoAndObject> intFields = new List<FieldInfoAndObject>();
    SyncListInt ints = new SyncListInt();

    List<FieldInfoAndObject> uintFields = new List<FieldInfoAndObject>();
    SyncListUInt uints = new SyncListUInt();

    List<FieldInfoAndObject> longFields = new List<FieldInfoAndObject>();
    SyncListLongWrapper longs = new SyncListLongWrapper();

    List<FieldInfoAndObject> boolFields = new List<FieldInfoAndObject>();
    SyncListBool bools = new SyncListBool();

    public static List<FieldInfo> GetFieldsWithAttribute(Type objectType, Type attributeType)
    {
        var result = new List<FieldInfo>();

        while (true)
        {
            var fields = objectType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(field => field.IsDefined(attributeType, true));

            result.AddRange(fields);

            objectType = objectType.BaseType;

            if (objectType == null)
                break;
        }

        return result;
    }

    // server & client: build field lists for each type. we assume that the
    // order is the same on client and server.
    void Awake()
    {
        // go through each networkbehaviour component
        foreach (var component in GetComponents<NetworkBehaviour>())
        {
            // find all the custom syncvars
            foreach (var field in GetFieldsWithAttribute(component.GetType(), typeof(SyncVar_Attribute)))
            {
                //Debug.LogWarning(component.GetType() + " => " + field + "=>" + field.GetValue(component));
                // add them to the field lists
                if (field.FieldType == typeof(string))
                    stringFields.Add(new FieldInfoAndObject(field, component));
                else if (field.FieldType == typeof(float))
                    floatFields.Add(new FieldInfoAndObject(field, component));
                else if (field.FieldType == typeof(int))
                    intFields.Add(new FieldInfoAndObject(field, component));
                else if (field.FieldType == typeof(uint))
                    uintFields.Add(new FieldInfoAndObject(field, component));
                else if (field.FieldType == typeof(long))
                    longFields.Add(new FieldInfoAndObject(field, component));
                else if (field.FieldType == typeof(bool))
                    boolFields.Add(new FieldInfoAndObject(field, component));
                else Debug.LogError("Unsupported [SyncVar_] type: " + field);
            }
        }
    }

    // server: populate the synclists with the field values
    public override void OnStartServer()
    {
        foreach (var fieldAndObject in stringFields)
        {
            //print("add string: " + fieldAndObject.field.GetValue(fieldAndObject.obj));
            strings.Add((string)fieldAndObject.field.GetValue(fieldAndObject.obj));
        }

        foreach (var fieldAndObject in floatFields)
        {
            //print("add float: " + fieldAndObject.field.GetValue(fieldAndObject.obj));
            floats.Add((float)fieldAndObject.field.GetValue(fieldAndObject.obj));
        }

        foreach (var fieldAndObject in intFields)
        {
            //print("add int: " + fieldAndObject.field.GetValue(fieldAndObject.obj));
            ints.Add((int)fieldAndObject.field.GetValue(fieldAndObject.obj));
        }

        foreach (var fieldAndObject in uintFields)
        {
            //print("add uint: " + fieldAndObject.field.GetValue(fieldAndObject.obj));
            uints.Add((uint)fieldAndObject.field.GetValue(fieldAndObject.obj));
        }

        foreach (var fieldAndObject in longFields)
        {
            //print("add long: " + fieldAndObject.field.GetValue(fieldAndObject.obj));
            longs.Add(new LongWrapper((long)fieldAndObject.field.GetValue(fieldAndObject.obj)));
        }

        foreach (var fieldAndObject in boolFields)
        {
            //print("add bool: " + fieldAndObject.field.GetValue(fieldAndObject.obj));
            bools.Add((bool)fieldAndObject.field.GetValue(fieldAndObject.obj));
        }
    }

    // server: copy field values to synclists all the time
    // (still works if obj becomes null)
    [ServerCallback]
    void Update()
    {
        for (int i = 0; i < stringFields.Count; ++i)
        {
            var fieldAndObject = stringFields[i];
            string value = (string)fieldAndObject.field.GetValue(fieldAndObject.obj);
            // only update if changed. don't mess with dirty flags.
            if (strings[i] != value) strings[i] = value;
        }

        for (int i = 0; i < floatFields.Count; ++i)
        {
            var fieldAndObject = floatFields[i];
            float value = (float)fieldAndObject.field.GetValue(fieldAndObject.obj);
            // only update if changed. don't mess with dirty flags.
            if (floats[i] != value) floats[i] = value;
        }

        for (int i = 0; i < intFields.Count; ++i)
        {
            var fieldAndObject = intFields[i];
            int value = (int)fieldAndObject.field.GetValue(fieldAndObject.obj);
            // only update if changed. don't mess with dirty flags.
            if (ints[i] != value) ints[i] = value;
        }

        for (int i = 0; i < uintFields.Count; ++i)
        {
            var fieldAndObject = uintFields[i];
            uint value = (uint)fieldAndObject.field.GetValue(fieldAndObject.obj);
            // only update if changed. don't mess with dirty flags.
            if (uints[i] != value) uints[i] = value;
        }

        for (int i = 0; i < longFields.Count; ++i)
        {
            var fieldAndObject = longFields[i];
            long value = (long)fieldAndObject.field.GetValue(fieldAndObject.obj);
            // only update if changed. don't mess with dirty flags.
            if (longs[i].value != value) longs[i] = new LongWrapper(value);
        }

        for (int i = 0; i < boolFields.Count; ++i)
        {
            var fieldAndObject = boolFields[i];
            bool value = (bool)fieldAndObject.field.GetValue(fieldAndObject.obj);
            // only update if changed. don't mess with dirty flags.
            if (bools[i] != value) bools[i] = value;
        }
    }

    // client: hook synclists and update fields when changed
    // (still works if obj becomes null)
    // we also call all hooks once to apply initial values
    // e.g. if a syncvar was set when loading from database before starting
    public override void OnStartClient()
    {
        strings.Callback += OnStringsChanged;
        for (int i = 0; i < strings.Count; ++i)
            OnStringsChanged(SyncListString.Operation.OP_ADD, i);

        floats.Callback += OnFloatsChanged;
        for (int i = 0; i < floats.Count; ++i)
            OnFloatsChanged(SyncListFloat.Operation.OP_ADD, i);

        ints.Callback += OnIntsChanged;
        for (int i = 0; i < ints.Count; ++i)
            OnIntsChanged(SyncListInt.Operation.OP_ADD, i);

        uints.Callback += OnUIntsChanged;
        for (int i = 0; i < uints.Count; ++i)
            OnUIntsChanged(SyncListUInt.Operation.OP_ADD, i);

        longs.Callback += OnLongsChanged;
        for (int i = 0; i < longs.Count; ++i)
            OnLongsChanged(SyncListLongWrapper.Operation.OP_ADD, i);

        bools.Callback += OnBoolsChanged;
        for (int i = 0; i < bools.Count; ++i)
            OnBoolsChanged(SyncListBool.Operation.OP_ADD, i);
    }

    void OnStringsChanged(SyncListString.Operation op, int index)
    {
        var fieldAndObject = stringFields[index];
        string value = strings[index];
        fieldAndObject.field.SetValue(fieldAndObject.obj, value);
        //print("STRING CHANGED: " + fieldAndObject.field + " => " + value);
    }

    void OnFloatsChanged(SyncListFloat.Operation op, int index)
    {
        var fieldAndObject = floatFields[index];
        float value = floats[index];
        fieldAndObject.field.SetValue(fieldAndObject.obj, value);
        //print("FLOAT CHANGED: " + fieldAndObject.field + " => " + value);
    }

    void OnIntsChanged(SyncListInt.Operation op, int index)
    {
        var fieldAndObject = intFields[index];
        int value = ints[index];
        fieldAndObject.field.SetValue(fieldAndObject.obj, value);
        //print("INT CHANGED: " + fieldAndObject.field + " => " + value);
    }

    void OnUIntsChanged(SyncListUInt.Operation op, int index)
    {
        var fieldAndObject = uintFields[index];
        uint value = uints[index];
        fieldAndObject.field.SetValue(fieldAndObject.obj, value);
        //print("UINT CHANGED: " + fieldAndObject.field + " => " + value);
    }

    void OnLongsChanged(SyncListLongWrapper.Operation op, int index)
    {
        var fieldAndObject = longFields[index];
        long value = longs[index].value;
        fieldAndObject.field.SetValue(fieldAndObject.obj, value);
        //print("LONG CHANGED: " + fieldAndObject.field + " => " + value);
    }

    void OnBoolsChanged(SyncListBool.Operation op, int index)
    {
        var fieldAndObject = boolFields[index];
        bool value = bools[index];
        fieldAndObject.field.SetValue(fieldAndObject.obj, value);
        //print("BOOL CHANGED: " + fieldAndObject.field + " => " + value);
    }
}
