using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MessageDispatcher
{


    public static void Send<T>(T message)
        {
        var objects = Resources.FindObjectsOfTypeAll<GameObject>();

         foreach (var obj in objects)
         {
            var components = obj.GetComponents<Component>();

            foreach(var component in components)
            {
                Send(message, component);
            }

         }
        }

    public static void Send<T>(T message, Component component) 
    {
        if (component == null)
        { return; }
        var type = component.GetType();
        var methods = type.GetMethods(
            
            System.Reflection.BindingFlags.Instance |
            System.Reflection.BindingFlags.NonPublic | 
            System.Reflection.BindingFlags.Public | 
            System.Reflection.BindingFlags.Static);
    

        foreach(var method in methods)
        {
            var parameters = method.GetParameters();
            if (parameters.Length !=1)
            { continue; }
            var param = parameters[0];
            if (param.ParameterType == message.GetType())
            {
                method.Invoke(component, new object[] { message });
            }
        }

    }

 public static void AddListner(Component component)
    {
        if (_Listeners.Contains(component)) { return; }
        _Listeners.Add(component);
    }

    private static readonly List<Component> _Listeners = new List<Component>();

    





}

