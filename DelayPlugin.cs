using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FlaxEngine;

namespace Game;

/// <summary>
/// DelayPlugin Script.
/// </summary>
public class Delay : GamePlugin
{
    public Delay()
    {
        // Initialize plugin description
        _description = new PluginDescription
        {
            Name = "Delay Plugin",
            Category = "Other",
            Description = "A Simple ASync Delay Plugin For Flax Engine",
            Author = "Ste3l",
        };
    }

    /// <inheritdoc />
    public override void Initialize()
    {
        base.Initialize();

        Debug.Log("Plugin initialization!");
    }

    public static void Invoke(Action Function, int DelayInMs)
    {
        Task.Run(async delegate
        {
            await Task.Delay(DelayInMs); // delay in miliseconds
            Scripting.InvokeOnUpdate(() =>
            {
                
                Function();
            });
            
        });
    }

    public static void Invoke<T>(Action<T> Function, T parameter, int DelayInMs)
    {
        Task.Run(async delegate
        {
            await Task.Delay(DelayInMs); // delay in miliseconds
            Scripting.InvokeOnUpdate(() =>
            {
                Function(parameter);
            });

        });
    }

    /// <inheritdoc />
    public override void Deinitialize()
    {
        Debug.Log("Plugin cleanup!");

        base.Deinitialize();
    }
}
