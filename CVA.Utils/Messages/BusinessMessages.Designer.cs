﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CVA.Utils.Messages {
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
    public class BusinessMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal BusinessMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("CVA.Utils.Messages.BusinessMessages", typeof(BusinessMessages).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The record &quot;{0}&quot; already exists in the database..
        /// </summary>
        public static string ExistingRecord {
            get {
                return ResourceManager.GetString("ExistingRecord", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The field &quot;{0}&quot; must be at most {1} characters long..
        /// </summary>
        public static string FieldMaxLength {
            get {
                return ResourceManager.GetString("FieldMaxLength", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The field &quot;{0}&quot; must be at least {1} characters long..
        /// </summary>
        public static string FieldMinLength {
            get {
                return ResourceManager.GetString("FieldMinLength", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The field &quot;{0}&quot; was not found..
        /// </summary>
        public static string FieldNotFound {
            get {
                return ResourceManager.GetString("FieldNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The field &quot;{0}&quot; is required..
        /// </summary>
        public static string FieldRequired {
            get {
                return ResourceManager.GetString("FieldRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The field &quot;{0}&quot; is invalid..
        /// </summary>
        public static string InvalidField {
            get {
                return ResourceManager.GetString("InvalidField", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The operation &quot;{0}&quot; was completed successfully..
        /// </summary>
        public static string OperationSuccessful {
            get {
                return ResourceManager.GetString("OperationSuccessful", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The record &quot;{0}&quot; was not found..
        /// </summary>
        public static string RecordNotFound {
            get {
                return ResourceManager.GetString("RecordNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The record &quot;{0}&quot; was removed..
        /// </summary>
        public static string RecordRemoved {
            get {
                return ResourceManager.GetString("RecordRemoved", resourceCulture);
            }
        }
    }
}