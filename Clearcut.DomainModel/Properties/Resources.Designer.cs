﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.225
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Clearcut.DomainModel.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Clearcut.DomainModel.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to BusinessObject::RegisterConstraints: errorMessage cannot be null.
        /// </summary>
        internal static string CONSTRAINT_REGISTRATION_ERROR_MESSAGE_CANNOT_BE_NULL {
            get {
                return ResourceManager.GetString("CONSTRAINT_REGISTRATION_ERROR_MESSAGE_CANNOT_BE_NULL", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to BusinessObject::RegisterConstraints: predicate cannot be null.
        /// </summary>
        internal static string CONSTRAINT_REGISTRATION_PREDICATE_CANNOT_BE_NULL {
            get {
                return ResourceManager.GetString("CONSTRAINT_REGISTRATION_PREDICATE_CANNOT_BE_NULL", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to BusinessObject::RegisterConstraints: targetProperty does not exists in type or in ancestor types.
        /// </summary>
        internal static string CONSTRAINT_REGISTRATION_PROPERTY_MUST_EXISTS {
            get {
                return ResourceManager.GetString("CONSTRAINT_REGISTRATION_PROPERTY_MUST_EXISTS", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Property name cannot be an empty string or a string containing only blanks.
        /// </summary>
        internal static string DOMAIN_OBJECT_VALIDATE_PROPERTY_NAME_CANNOT_BE_ALL_BLANKS {
            get {
                return ResourceManager.GetString("DOMAIN_OBJECT_VALIDATE_PROPERTY_NAME_CANNOT_BE_ALL_BLANKS", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Property name cannot be null.
        /// </summary>
        internal static string DOMAIN_OBJECT_VALIDATE_PROPERTY_NAME_CANNOT_BE_NULL {
            get {
                return ResourceManager.GetString("DOMAIN_OBJECT_VALIDATE_PROPERTY_NAME_CANNOT_BE_NULL", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Property does not exist.
        /// </summary>
        internal static string DOMAIN_OBJECT_VALIDATE_PROPERTY_NAME_MUST_EXIST {
            get {
                return ResourceManager.GetString("DOMAIN_OBJECT_VALIDATE_PROPERTY_NAME_MUST_EXIST", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Precondition errorMessage cannot be null.
        /// </summary>
        internal static string PRECONDITION_ERROR_MESSAGE_CANNOT_BE_NULL {
            get {
                return ResourceManager.GetString("PRECONDITION_ERROR_MESSAGE_CANNOT_BE_NULL", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to target property cannot be null.
        /// </summary>
        internal static string TARGET_PROPERTY_CANNOT_BE_NULL {
            get {
                return ResourceManager.GetString("TARGET_PROPERTY_CANNOT_BE_NULL", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to type cannot be null.
        /// </summary>
        internal static string TYPE_CANNOT_BE_NULL {
            get {
                return ResourceManager.GetString("TYPE_CANNOT_BE_NULL", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Use case actor cannot be null.
        /// </summary>
        internal static string USE_CASE_ACTOR_CANNOT_BE_NULL {
            get {
                return ResourceManager.GetString("USE_CASE_ACTOR_CANNOT_BE_NULL", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Use case scenario cannot be null.
        /// </summary>
        internal static string USE_CASE_SCENARIO_CANNOT_BE_NULL {
            get {
                return ResourceManager.GetString("USE_CASE_SCENARIO_CANNOT_BE_NULL", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Authorization failed.
        /// </summary>
        internal static string USER_AUTHORIZATION_FAILED {
            get {
                return ResourceManager.GetString("USER_AUTHORIZATION_FAILED", resourceCulture);
            }
        }
    }
}