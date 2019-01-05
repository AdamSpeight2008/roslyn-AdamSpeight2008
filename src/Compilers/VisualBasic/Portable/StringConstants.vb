' Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

Namespace Microsoft.CodeAnalysis.VisualBasic
  Friend NotInheritable Class StringConstants
    Private Sub New()
    End Sub

    #Region "non localizable strings"
    Friend Const AnonymousMethodName                        = "<anonymous method>"
    Friend Const AnonymousTypeName                          = "<anonymous type>"
    Friend Const AsEnumerableMethod                         = "AsEnumerable"
    Friend Const AsQueryableMethod                          = "AsQueryable"
    Friend Const CastMethod                                 = "Cast"
    Friend Const DelegateConstructorInstanceParameterName   = "TargetObject"
    Friend Const DelegateConstructorMethodParameterName     = "TargetMethod"
    Friend Const DelegateMethodCallbackParameterName        = "DelegateCallback"
    Friend Const DelegateMethodInstanceParameterName        = "DelegateAsyncState"
    Friend Const DelegateMethodResultParameterName          = "DelegateAsyncResult"
    Friend Const DelegateStubParameterPrefix                = "a"
    Friend Const DistinctMethod                             = "Distinct"
    Friend Const ElementAtMethod                            = "ElementAtOrDefault"
    Friend Const Group                                      = "$VB$Group"
    Friend Const GroupByMethod                              = "GroupBy"
    Friend Const GroupJoinMethod                            = "GroupJoin"
    Friend Const It                                         = "$VB$It"
    Friend Const It1                                        = "$VB$It1"
    Friend Const It2                                        = "$VB$It2"
    Friend Const ItAnonymous                                = "$VB$ItAnonymous"
    Friend Const JoinMethod                                 = "Join"
    Friend Const Lambda                                     = "Lambda"
    Friend Const NamedSymbolErrorName                       = "?"
    Friend Const OrderByDescendingMethod                    = "OrderByDescending"
    Friend Const OrderByMethod                              = "OrderBy"
    Friend Const SelectManyMethod                           = "SelectMany"
    Friend Const SelectMethod                               = "Select"
    Friend Const SkipMethod                                 = "Skip"
    Friend Const SkipWhileMethod                            = "SkipWhile"
    Friend Const TakeMethod                                 = "Take"
    Friend Const TakeWhileMethod                            = "TakeWhile"
    Friend Const ThenByDescendingMethod                     = "ThenByDescending"
    Friend Const ThenByMethod                               = "ThenBy"
    Friend Const UnnamedNamespaceErrName                    = "<Default>"
    Friend Const WhereMethod                                = "Where"
    #End Region
    ' EE recognized names (prefixes):
    Friend Const ClosureVariablePrefix                      = "$VB$Closure_"
    Friend Const DisplayClassPrefix                         = "_Closure$__"
    Friend Const HoistedMeName                              = "$VB$Me"
    Friend Const HoistedUserVariablePrefix                  = "$VB$Local_"
    Friend Const HoistedSpecialVariablePrefix               = "$VB$NonLocal_" ' prefixes Me and Closure variables when hoisted
    Friend Const HoistedWithLocalPrefix                     = "$W"
    Friend Const StateMachineHoistedUserVariablePrefix      = "$VB$ResumableLocal_"
    Friend Const StateMachineTypeNamePrefix                 = "VB$StateMachine_"
    
    ' Do not change the following strings. Other teams (FxCop) use this string to identify lambda functions in its analysis
    ' If you have to change this string, please contact the VB language PM and consider the impact of that break.
    Friend Const BaseMethodWrapperNamePrefix                = "$VB$ClosureStub_"
    Friend Const DisplayClassGenericParameterNamePrefix     = "$CLS"
    Friend Const LambdaMethodNamePrefix                     = "_Lambda$__"

    #Region "Dependant String: Microsoft.VisualStudio.VIL.VisualStudioHost.AsyncReturnStackFrame"
    Friend Const AutoPropertyValueParameterName             = "AutoPropertyValue"
    Friend Const DefaultXmlnsPrefix                         = ""
    Friend Const DefaultXmlNamespace                        = ""    
    Friend Const DelegateRelaxationDisplayClassPrefix       = DisplayClassPrefix & "R"
    Friend Const DelegateRelaxationMethodNamePrefix         = LambdaMethodNamePrefix & "R"
    Friend Const DelegateRelaxationCacheFieldPrefix         = "$IR"
    Friend Const HoistedSynthesizedLocalPrefix              = "$S"
    Friend Const IteratorCurrentFieldName                   = "$Current"
    Friend Const IteratorInitialThreadIdName                = "$InitialThreadId"
    Friend Const IteratorParameterProxyPrefix               = "$P_"
    Friend Const LambdaCacheFieldPrefix                     = "$I"
    Friend Const PropertyGetPrefix                          = "get_"
    Friend Const PropertySetPrefix                          = "set_"
    Friend Const ReusableHoistedLocalFieldName              = "$U"
    Friend Const StateMachineAwaiterFieldPrefix             = "$A"
    Friend Const StateMachineExpressionCapturePrefix        = "$V"
    Friend Const StateMachineBuilderFieldName               = "$Builder"
    Friend Const StateMachineStateFieldName                 = "$State"
    Friend Const StateMachineTypeParameterPrefix            = "SM$"
    Friend Const StaticLocalFieldNamePrefix                 = "$STATIC$"    
    Friend Const ValueParameterName                         = "Value"   
    Friend Const ValueProperty                              = "Value"
    Friend Const WinMdPropertySetPrefix                     = "put_"    
    Friend Const WithEventsValueParameterName               = "WithEventsValue"    
    Friend Const XmlPrefix                                  = "xml"
    Friend Const XmlNamespace                               = "http://www.w3.org/XML/1998/namespace"
    Friend Const XmlnsPrefix                                = "xmlns"
    Friend Const XmlnsNamespace                             = "http://www.w3.org/2000/xmlns/"
    Friend Const XmlAddMethodName                           = "Add"
    Friend Const XmlGetMethodName                           = "Get"
    Friend Const XmlElementsMethodName                      = "Elements"
    Friend Const XmlDescendantsMethodName                   = "Descendants"
    Friend Const XmlAttributeValueMethodName                = "AttributeValue"
    Friend Const XmlCreateAttributeMethodName               = "CreateAttribute"
    Friend Const XmlCreateNamespaceAttributeMethodName      = "CreateNamespaceAttribute"
    Friend Const XmlRemoveNamespaceAttributesMethodName     = "RemoveNamespaceAttributes"
    #End Region
  End Class

  Friend Module Constants
    Friend Const ATTACH_LISTENER_PREFIX = "add_"
    Friend Const REMOVE_LISTENER_PREFIX = "remove_"
    Friend Const FIRE_LISTENER_PREFIX   = "raise_"
    Friend Const EVENT_DELEGATE_SUFFIX  = "EventHandler"
    Friend Const EVENT_VARIABLE_SUFFIX  = "Event"
  End Module

End Namespace
