﻿' Definition of syntax model.
' DO NOT HAND EDIT

Namespace Microsoft.CodeAnalysis.VisualBasic
    Partial Public Class SyntaxFacts
        ''' <summary>
        ''' Return keyword or punctuation text based on SyntaxKind
        ''' </summary>
        Public Shared Function GetText(kind As SyntaxKind) As String
            Select Case kind
        Case SyntaxKind.AddHandlerKeyword
            Return "AddHandler"
        Case SyntaxKind.AddressOfKeyword
            Return "AddressOf"
        Case SyntaxKind.AliasKeyword
            Return "Alias"
        Case SyntaxKind.AndKeyword
            Return "And"
        Case SyntaxKind.AndAlsoKeyword
            Return "AndAlso"
        Case SyntaxKind.AsKeyword
            Return "As"
        Case SyntaxKind.BooleanKeyword
            Return "Boolean"
        Case SyntaxKind.ByRefKeyword
            Return "ByRef"
        Case SyntaxKind.ByteKeyword
            Return "Byte"
        Case SyntaxKind.ByValKeyword
            Return "ByVal"
        Case SyntaxKind.CallKeyword
            Return "Call"
        Case SyntaxKind.CaseKeyword
            Return "Case"
        Case SyntaxKind.CatchKeyword
            Return "Catch"
        Case SyntaxKind.CBoolKeyword
            Return "CBool"
        Case SyntaxKind.CByteKeyword
            Return "CByte"
        Case SyntaxKind.CCharKeyword
            Return "CChar"
        Case SyntaxKind.CDateKeyword
            Return "CDate"
        Case SyntaxKind.CDecKeyword
            Return "CDec"
        Case SyntaxKind.CDblKeyword
            Return "CDbl"
        Case SyntaxKind.CharKeyword
            Return "Char"
        Case SyntaxKind.CIntKeyword
            Return "CInt"
        Case SyntaxKind.ClassKeyword
            Return "Class"
        Case SyntaxKind.CLngKeyword
            Return "CLng"
        Case SyntaxKind.CObjKeyword
            Return "CObj"
        Case SyntaxKind.ConstKeyword
            Return "Const"
        Case SyntaxKind.ReferenceKeyword
            Return "R"
        Case SyntaxKind.ContinueKeyword
            Return "Continue"
        Case SyntaxKind.CSByteKeyword
            Return "CSByte"
        Case SyntaxKind.CShortKeyword
            Return "CShort"
        Case SyntaxKind.CSngKeyword
            Return "CSng"
        Case SyntaxKind.CStrKeyword
            Return "CStr"
        Case SyntaxKind.CTypeKeyword
            Return "CType"
        Case SyntaxKind.CUIntKeyword
            Return "CUInt"
        Case SyntaxKind.CULngKeyword
            Return "CULng"
        Case SyntaxKind.CUShortKeyword
            Return "CUShort"
        Case SyntaxKind.DateKeyword
            Return "Date"
        Case SyntaxKind.DecimalKeyword
            Return "Decimal"
        Case SyntaxKind.DeclareKeyword
            Return "Declare"
        Case SyntaxKind.DefaultKeyword
            Return "Default"
        Case SyntaxKind.DelegateKeyword
            Return "Delegate"
        Case SyntaxKind.DimKeyword
            Return "Dim"
        Case SyntaxKind.DirectCastKeyword
            Return "DirectCast"
        Case SyntaxKind.DoKeyword
            Return "Do"
        Case SyntaxKind.DoubleKeyword
            Return "Double"
        Case SyntaxKind.EachKeyword
            Return "Each"
        Case SyntaxKind.ElseKeyword
            Return "Else"
        Case SyntaxKind.ElseIfKeyword
            Return "ElseIf"
        Case SyntaxKind.EndKeyword
            Return "End"
        Case SyntaxKind.EnumKeyword
            Return "Enum"
        Case SyntaxKind.EraseKeyword
            Return "Erase"
        Case SyntaxKind.ErrorKeyword
            Return "Error"
        Case SyntaxKind.EventKeyword
            Return "Event"
        Case SyntaxKind.ExitKeyword
            Return "Exit"
        Case SyntaxKind.FalseKeyword
            Return "False"
        Case SyntaxKind.FinallyKeyword
            Return "Finally"
        Case SyntaxKind.ForKeyword
            Return "For"
        Case SyntaxKind.FriendKeyword
            Return "Friend"
        Case SyntaxKind.FunctionKeyword
            Return "Function"
        Case SyntaxKind.GetKeyword
            Return "Get"
        Case SyntaxKind.GetTypeKeyword
            Return "GetType"
        Case SyntaxKind.GetXmlNamespaceKeyword
            Return "GetXmlNamespace"
        Case SyntaxKind.GlobalKeyword
            Return "Global"
        Case SyntaxKind.GoToKeyword
            Return "GoTo"
        Case SyntaxKind.HandlesKeyword
            Return "Handles"
        Case SyntaxKind.IfKeyword
            Return "If"
        Case SyntaxKind.ImplementsKeyword
            Return "Implements"
        Case SyntaxKind.ImportsKeyword
            Return "Imports"
        Case SyntaxKind.InKeyword
            Return "In"
        Case SyntaxKind.InheritsKeyword
            Return "Inherits"
        Case SyntaxKind.IntegerKeyword
            Return "Integer"
        Case SyntaxKind.InterfaceKeyword
            Return "Interface"
        Case SyntaxKind.IsKeyword
            Return "Is"
        Case SyntaxKind.IsNotKeyword
            Return "IsNot"
        Case SyntaxKind.LetKeyword
            Return "Let"
        Case SyntaxKind.LibKeyword
            Return "Lib"
        Case SyntaxKind.LikeKeyword
            Return "Like"
        Case SyntaxKind.LongKeyword
            Return "Long"
        Case SyntaxKind.LoopKeyword
            Return "Loop"
        Case SyntaxKind.MeKeyword
            Return "Me"
        Case SyntaxKind.ModKeyword
            Return "Mod"
        Case SyntaxKind.ModuleKeyword
            Return "Module"
        Case SyntaxKind.MustInheritKeyword
            Return "MustInherit"
        Case SyntaxKind.MustOverrideKeyword
            Return "MustOverride"
        Case SyntaxKind.MyBaseKeyword
            Return "MyBase"
        Case SyntaxKind.MyClassKeyword
            Return "MyClass"
        Case SyntaxKind.NameOfKeyword
            Return "NameOf"
        Case SyntaxKind.NamespaceKeyword
            Return "Namespace"
        Case SyntaxKind.NarrowingKeyword
            Return "Narrowing"
        Case SyntaxKind.NextKeyword
            Return "Next"
        Case SyntaxKind.NewKeyword
            Return "New"
        Case SyntaxKind.NotKeyword
            Return "Not"
        Case SyntaxKind.NothingKeyword
            Return "Nothing"
        Case SyntaxKind.NotInheritableKeyword
            Return "NotInheritable"
        Case SyntaxKind.NotOverridableKeyword
            Return "NotOverridable"
        Case SyntaxKind.ObjectKeyword
            Return "Object"
        Case SyntaxKind.OfKeyword
            Return "Of"
        Case SyntaxKind.OnKeyword
            Return "On"
        Case SyntaxKind.OperatorKeyword
            Return "Operator"
        Case SyntaxKind.OptionKeyword
            Return "Option"
        Case SyntaxKind.OptionalKeyword
            Return "Optional"
        Case SyntaxKind.OrKeyword
            Return "Or"
        Case SyntaxKind.OrElseKeyword
            Return "OrElse"
        Case SyntaxKind.OverloadsKeyword
            Return "Overloads"
        Case SyntaxKind.OverridableKeyword
            Return "Overridable"
        Case SyntaxKind.OverridesKeyword
            Return "Overrides"
        Case SyntaxKind.ParamArrayKeyword
            Return "ParamArray"
        Case SyntaxKind.PartialKeyword
            Return "Partial"
        Case SyntaxKind.PrivateKeyword
            Return "Private"
        Case SyntaxKind.PropertyKeyword
            Return "Property"
        Case SyntaxKind.ProtectedKeyword
            Return "Protected"
        Case SyntaxKind.PublicKeyword
            Return "Public"
        Case SyntaxKind.RaiseEventKeyword
            Return "RaiseEvent"
        Case SyntaxKind.ReadOnlyKeyword
            Return "ReadOnly"
        Case SyntaxKind.ReDimKeyword
            Return "ReDim"
        Case SyntaxKind.REMKeyword
            Return "REM"
        Case SyntaxKind.RemoveHandlerKeyword
            Return "RemoveHandler"
        Case SyntaxKind.ResumeKeyword
            Return "Resume"
        Case SyntaxKind.ReturnKeyword
            Return "Return"
        Case SyntaxKind.SByteKeyword
            Return "SByte"
        Case SyntaxKind.SelectKeyword
            Return "Select"
        Case SyntaxKind.SetKeyword
            Return "Set"
        Case SyntaxKind.ShadowsKeyword
            Return "Shadows"
        Case SyntaxKind.SharedKeyword
            Return "Shared"
        Case SyntaxKind.ShortKeyword
            Return "Short"
        Case SyntaxKind.SingleKeyword
            Return "Single"
        Case SyntaxKind.StaticKeyword
            Return "Static"
        Case SyntaxKind.StepKeyword
            Return "Step"
        Case SyntaxKind.StopKeyword
            Return "Stop"
        Case SyntaxKind.StringKeyword
            Return "String"
        Case SyntaxKind.StructureKeyword
            Return "Structure"
        Case SyntaxKind.SubKeyword
            Return "Sub"
        Case SyntaxKind.SyncLockKeyword
            Return "SyncLock"
        Case SyntaxKind.ThenKeyword
            Return "Then"
        Case SyntaxKind.ThrowKeyword
            Return "Throw"
        Case SyntaxKind.ToKeyword
            Return "To"
        Case SyntaxKind.TrueKeyword
            Return "True"
        Case SyntaxKind.TryKeyword
            Return "Try"
        Case SyntaxKind.TryCastKeyword
            Return "TryCast"
        Case SyntaxKind.TypeOfKeyword
            Return "TypeOf"
        Case SyntaxKind.UIntegerKeyword
            Return "UInteger"
        Case SyntaxKind.ULongKeyword
            Return "ULong"
        Case SyntaxKind.UShortKeyword
            Return "UShort"
        Case SyntaxKind.UsingKeyword
            Return "Using"
        Case SyntaxKind.WhenKeyword
            Return "When"
        Case SyntaxKind.WhileKeyword
            Return "While"
        Case SyntaxKind.WideningKeyword
            Return "Widening"
        Case SyntaxKind.WithKeyword
            Return "With"
        Case SyntaxKind.WithEventsKeyword
            Return "WithEvents"
        Case SyntaxKind.WriteOnlyKeyword
            Return "WriteOnly"
        Case SyntaxKind.XorKeyword
            Return "Xor"
        Case SyntaxKind.EndIfKeyword
            Return "EndIf"
        Case SyntaxKind.GosubKeyword
            Return "Gosub"
        Case SyntaxKind.VariantKeyword
            Return "Variant"
        Case SyntaxKind.WendKeyword
            Return "Wend"
        Case SyntaxKind.Language_Keyword
            Return "Language"
        Case SyntaxKind.Grammar_Keyword
            Return "Grammar"
        Case SyntaxKind.Syntax_Keyword
            Return "Syntax"
        Case SyntaxKind.Kinds_Keyword
            Return "Kinds"
        Case SyntaxKind.Keywords_Keyword
            Return "Keywords"
        Case SyntaxKind.AggregateKeyword
            Return "Aggregate"
        Case SyntaxKind.AllKeyword
            Return "All"
        Case SyntaxKind.AnsiKeyword
            Return "Ansi"
        Case SyntaxKind.AscendingKeyword
            Return "Ascending"
        Case SyntaxKind.AssemblyKeyword
            Return "Assembly"
        Case SyntaxKind.AutoKeyword
            Return "Auto"
        Case SyntaxKind.BinaryKeyword
            Return "Binary"
        Case SyntaxKind.ByKeyword
            Return "By"
        Case SyntaxKind.CompareKeyword
            Return "Compare"
        Case SyntaxKind.CustomKeyword
            Return "Custom"
        Case SyntaxKind.DescendingKeyword
            Return "Descending"
        Case SyntaxKind.DisableKeyword
            Return "Disable"
        Case SyntaxKind.DistinctKeyword
            Return "Distinct"
        Case SyntaxKind.EnableKeyword
            Return "Enable"
        Case SyntaxKind.EqualsKeyword
            Return "Equals"
        Case SyntaxKind.ExplicitKeyword
            Return "Explicit"
        Case SyntaxKind.ExternalSourceKeyword
            Return "ExternalSource"
        Case SyntaxKind.ExternalChecksumKeyword
            Return "ExternalChecksum"
        Case SyntaxKind.FromKeyword
            Return "From"
        Case SyntaxKind.GroupKeyword
            Return "Group"
        Case SyntaxKind.InferKeyword
            Return "Infer"
        Case SyntaxKind.IntoKeyword
            Return "Into"
        Case SyntaxKind.IsFalseKeyword
            Return "IsFalse"
        Case SyntaxKind.IsTrueKeyword
            Return "IsTrue"
        Case SyntaxKind.JoinKeyword
            Return "Join"
        Case SyntaxKind.KeyKeyword
            Return "Key"
        Case SyntaxKind.MidKeyword
            Return "Mid"
        Case SyntaxKind.OffKeyword
            Return "Off"
        Case SyntaxKind.OrderKeyword
            Return "Order"
        Case SyntaxKind.OutKeyword
            Return "Out"
        Case SyntaxKind.PreserveKeyword
            Return "Preserve"
        Case SyntaxKind.RegionKeyword
            Return "Region"
        Case SyntaxKind.SkipKeyword
            Return "Skip"
        Case SyntaxKind.StrictKeyword
            Return "Strict"
        Case SyntaxKind.TakeKeyword
            Return "Take"
        Case SyntaxKind.TextKeyword
            Return "Text"
        Case SyntaxKind.UnicodeKeyword
            Return "Unicode"
        Case SyntaxKind.UntilKeyword
            Return "Until"
        Case SyntaxKind.WarningKeyword
            Return "Warning"
        Case SyntaxKind.WhereKeyword
            Return "Where"
        Case SyntaxKind.TypeKeyword
            Return "Type"
        Case SyntaxKind.XmlKeyword
            Return "xml"
        Case SyntaxKind.AsyncKeyword
            Return "Async"
        Case SyntaxKind.AwaitKeyword
            Return "Await"
        Case SyntaxKind.IteratorKeyword
            Return "Iterator"
        Case SyntaxKind.YieldKeyword
            Return "Yield"
        Case SyntaxKind.ExclamationToken
            Return "!"
        Case SyntaxKind.AtToken
            Return "@"
        Case SyntaxKind.CommaToken
            Return ","
        Case SyntaxKind.HashToken
            Return "#"
        Case SyntaxKind.AmpersandToken
            Return "&"
        Case SyntaxKind.SingleQuoteToken
            Return "'"
        Case SyntaxKind.OpenParenToken
            Return "("
        Case SyntaxKind.CloseParenToken
            Return ")"
        Case SyntaxKind.OpenBraceToken
            Return "{"
        Case SyntaxKind.CloseBraceToken
            Return "}"
        Case SyntaxKind.SemicolonToken
            Return ";"
        Case SyntaxKind.AsteriskToken
            Return "*"
        Case SyntaxKind.PlusToken
            Return "+"
        Case SyntaxKind.MinusToken
            Return "-"
        Case SyntaxKind.DotToken
            Return "."
        Case SyntaxKind.SlashToken
            Return "/"
        Case SyntaxKind.ColonToken
            Return ":"
        Case SyntaxKind.LessThanToken
            Return "<"
        Case SyntaxKind.LessThanEqualsToken
            Return "<="
        Case SyntaxKind.LessThanGreaterThanToken
            Return "<>"
        Case SyntaxKind.EqualsToken
            Return "="
        Case SyntaxKind.GreaterThanToken
            Return ">"
        Case SyntaxKind.GreaterThanEqualsToken
            Return ">="
        Case SyntaxKind.BackslashToken
            Return "\"
        Case SyntaxKind.CaretToken
            Return "^"
        Case SyntaxKind.ColonEqualsToken
            Return ":="
        Case SyntaxKind.AmpersandEqualsToken
            Return "&="
        Case SyntaxKind.AsteriskEqualsToken
            Return "*="
        Case SyntaxKind.PlusEqualsToken
            Return "+="
        Case SyntaxKind.MinusEqualsToken
            Return "-="
        Case SyntaxKind.SlashEqualsToken
            Return "/="
        Case SyntaxKind.BackslashEqualsToken
            Return "\="
        Case SyntaxKind.CaretEqualsToken
            Return "^="
        Case S