﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TipCalculator.Resources.Languages {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Localization {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Localization() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("TipCalculator.Resources.Languages.Localization", typeof(Localization).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Bill.
        /// </summary>
        internal static string Bill_Label {
            get {
                return ResourceManager.GetString("Bill_Label", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Enter Amount.
        /// </summary>
        internal static string Bill_Placeholder {
            get {
                return ResourceManager.GetString("Bill_Placeholder", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Tip percentage.
        /// </summary>
        internal static string Percentage_Label {
            get {
                return ResourceManager.GetString("Percentage_Label", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Round Down.
        /// </summary>
        internal static string RoundDown_Button {
            get {
                return ResourceManager.GetString("RoundDown_Button", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Round up.
        /// </summary>
        internal static string RoundUp_Button {
            get {
                return ResourceManager.GetString("RoundUp_Button", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Tip.
        /// </summary>
        internal static string Tip_Label {
            get {
                return ResourceManager.GetString("Tip_Label", resourceCulture);
            }
        }
    }
}
