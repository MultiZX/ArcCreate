using System;
using System.Collections.Generic;
using System.Reflection;

namespace ArcCreate.Compose.Navigation
{
    public class EditorAction : IAction
    {
        public EditorAction(
            string id,
            bool shouldDisplayOnContextMenu,
            List<IContextRequirement> contextRequirements,
            List<Type> whitelist,
            EditorScope scope,
            MethodInfo method,
            List<SubAction> subActions)
        {
            DisplayName = id;
            ShouldDisplayOnContextMenu = shouldDisplayOnContextMenu;
            ContextRequirements = contextRequirements;
            Whitelist = whitelist;
            Scope = scope;
            Method = method;
            SubActions = subActions;

            bool shouldPassSelf = method.GetParameters().Length != 0;
            if (shouldPassSelf)
            {
                ParamsToPass = new object[] { this };
            }
            else
            {
                ParamsToPass = new object[0];
            }
        }

        public string DisplayName { get; private set; }

        public bool ShouldDisplayOnContextMenu { get; private set; }

        public List<IContextRequirement> ContextRequirements { get; private set; }

        public List<Type> Whitelist { get; private set; }

        public EditorScope Scope { get; private set; }

        public MethodInfo Method { get; private set; }

        public List<SubAction> SubActions { get; private set; }

        public object[] ParamsToPass { get; private set; }

        public void Execute()
        {
            Services.Navigation.StartAction(this);
        }

        public SubAction GetSubAction(string id)
        {
            foreach (SubAction sub in SubActions)
            {
                if (sub.Id == id)
                {
                    return sub;
                }
            }

            throw new Exception($"Invalid sub-action id {id}");
        }

        public bool CheckRequirement()
        {
            foreach (IContextRequirement requirement in ContextRequirements)
            {
                if (!requirement.CheckRequirement())
                {
                    return false;
                }
            }

            return true;
        }
    }
}