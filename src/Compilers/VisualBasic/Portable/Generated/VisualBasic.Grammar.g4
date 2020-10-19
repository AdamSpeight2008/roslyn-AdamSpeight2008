﻿// <auto-generated />
grammar vb;

compilation_unit
  : option_statement* imports_statement* attributes_statement* statement*
  ;

option_statement
  : 'Option' ('Explicit' | 'Strict' | 'Compare' | 'Infer') ('On' | 'Off' | 'Text' | 'Binary')?
  ;

imports_statement
  : 'Imports' imports_clause (',' imports_clause)*
  ;

imports_clause
  : simple_imports_clause
  | xml_namespace_imports_clause
  ;

simple_imports_clause
  : import_alias_clause? name
  ;

import_alias_clause
  : identifier_token '='
  ;

xml_namespace_imports_clause
  : '<' xml_attribute '>'
  ;

xml_attribute
  : xml_node '=' xml_node
  ;

attributes_statement
  : attribute_list*
  ;

attribute_list
  : '<' attribute (',' attribute)* '>'
  ;

attribute
  : attribute_target? type argument_list?
  ;

attribute_target
  : 'Assembly' ':'
  | 'Module' ':'
  ;

argument_list
  : '(' (argument (',' argument)*)? ')'
  ;

argument
  : omitted_argument
  | range_argument
  | simple_argument
  ;

omitted_argument
  : empty_token
  ;

range_argument
  : expression 'To' expression
  ;

simple_argument
  : name_colon_equals? expression
  ;

name_colon_equals
  : identifier_name ':='
  ;

identifier_name
  : identifier_token
  ;

statement
  : case_statement
  | catch_statement
  | declaration_statement
  | do_statement
  | else_if_statement
  | else_statement
  | empty_statement
  | executable_statement
  | finally_statement
  | for_or_for_each_statement
  | if_statement
  | loop_statement
  | next_statement
  | select_statement
  | sync_lock_statement
  | try_statement
  | using_statement
  | while_statement
  | with_statement
  ;

case_statement
  : 'Case' case_clause (',' case_clause)*
  ;

case_clause
  : else_case_clause
  | range_case_clause
  | relational_case_clause
  | simple_case_clause
  ;

else_case_clause
  : 'Else'
  ;

range_case_clause
  : expression 'To' expression
  ;

relational_case_clause
  : case_equals_clause
  | case_greater_than_clause
  | case_greater_than_or_equal_clause
  | case_less_than_clause
  | case_less_than_or_equal_clause
  | case_not_equals_clause
  ;

case_equals_clause
  : 'Is'? '=' expression
  ;

case_greater_than_clause
  : 'Is'? '>=' expression
  ;

case_greater_than_or_equal_clause
  : 'Is'? '<=' expression
  ;

case_less_than_clause
  : 'Is'? '<' expression
  ;

case_less_than_or_equal_clause
  : 'Is'? '>' expression
  ;

case_not_equals_clause
  : 'Is'? '<>' expression
  ;

simple_case_clause
  : expression
  ;

catch_statement
  : 'Catch' identifier_name? simple_as_clause? catch_filter_clause?
  ;

simple_as_clause
  : 'As' attribute_list* type
  ;

catch_filter_clause
  : 'When' expression
  ;

declaration_statement
  : attributes_statement
  | end_block_statement
  | enum_block
  | enum_member_declaration
  | enum_statement
  | event_block
  | field_declaration
  | imports_statement
  | incomplete_member
  | inherits_or_implements_statement
  | method_base
  | method_block_base
  | namespace_block
  | namespace_statement
  | option_statement
  | property_block
  | type_block
  | type_statement
  ;

end_block_statement
  : end_add_handler_statement
  | end_class_statement
  | end_enum_statement
  | end_event_statement
  | end_function_statement
  | end_get_statement
  | end_if_statement
  | end_interface_statement
  | end_module_statement
  | end_namespace_statement
  | end_operator_statement
  | end_property_statement
  | end_raise_event_statement
  | end_remove_handler_statement
  | end_select_statement
  | end_set_statement
  | end_structure_statement
  | end_sub_statement
  | end_sync_lock_statement
  | end_try_statement
  | end_using_statement
  | end_while_statement
  | end_with_statement
  ;

end_add_handler_statement
  : 'End' 'AddHandler'
  ;

end_class_statement
  : 'End' 'Class'
  ;

end_enum_statement
  : 'End' 'Enum'
  ;

end_event_statement
  : 'End' 'Event'
  ;

end_function_statement
  : 'End' 'Function'
  ;

end_get_statement
  : 'End' 'Get'
  ;

end_if_statement
  : 'End' 'If'
  ;

end_interface_statement
  : 'End' 'Interface'
  ;

end_module_statement
  : 'End' 'Module'
  ;

end_namespace_statement
  : 'End' 'Namespace'
  ;

end_operator_statement
  : 'End' 'Operator'
  ;

end_property_statement
  : 'End' 'Property'
  ;

end_raise_event_statement
  : 'End' 'RaiseEvent'
  ;

end_remove_handler_statement
  : 'End' 'RemoveHandler'
  ;

end_select_statement
  : 'End' 'Select'
  ;

end_set_statement
  : 'End' 'Set'
  ;

end_structure_statement
  : 'End' 'Structure'
  ;

end_sub_statement
  : 'End' 'Sub'
  ;

end_sync_lock_statement
  : 'End' 'SyncLock'
  ;

end_try_statement
  : 'End' 'Try'
  ;

end_using_statement
  : 'End' 'Using'
  ;

end_while_statement
  : 'End' 'While'
  ;

end_with_statement
  : 'End' 'With'
  ;

enum_block
  : enum_statement statement* end_enum_statement
  ;

enum_statement
  : attribute_list* modifier* 'Enum' identifier_token as_clause?
  ;

as_clause
  : as_new_clause
  | simple_as_clause
  ;

as_new_clause
  : 'As' new_expression
  ;

new_expression
  : anonymous_object_creation_expression
  | array_creation_expression
  | object_creation_expression
  ;

anonymous_object_creation_expression
  : 'New' attribute_list* object_member_initializer
  ;

object_member_initializer
  : 'With' '{' (field_initializer (',' field_initializer)*)? '}'
  ;

field_initializer
  : inferred_field_initializer
  | named_field_initializer
  ;

inferred_field_initializer
  : 'Key'? expression
  ;

named_field_initializer
  : 'Key'? '.' identifier_name '=' expression
  ;

array_creation_expression
  : 'New' attribute_list* type argument_list? array_rank_specifier* collection_initializer
  ;

array_rank_specifier
  : '(' ','* ')'
  ;

collection_initializer
  : '{' (expression (',' expression)*)? '}'
  ;

object_creation_expression
  : 'New' attribute_list* type argument_list? object_creation_initializer?
  ;

object_creation_initializer
  : object_collection_initializer
  | object_member_initializer
  ;

object_collection_initializer
  : 'From' collection_initializer
  ;

enum_member_declaration
  : attribute_list* identifier_token equals_value?
  ;

equals_value
  : '=' expression
  ;

event_block
  : event_statement accessor_block* end_event_statement
  ;

event_statement
  : attribute_list* modifier* 'Custom'? 'Event' identifier_token parameter_list? simple_as_clause? implements_clause?
  ;

parameter_list
  : '(' (parameter (',' parameter)*)? ')'
  ;

parameter
  : attribute_list* modifier* modified_identifier simple_as_clause? equals_value?
  ;

modified_identifier
  : identifier_token '?'? argument_list? array_rank_specifier*
  ;

implements_clause
  : 'Implements' (qualified_name (',' qualified_name)*)?
  ;

qualified_name
  : name '.' simple_name
  ;

simple_name
  : generic_name
  | identifier_name
  ;

generic_name
  : identifier_token type_argument_list
  ;

type_argument_list
  : '(' 'Of' type (',' type)* ')'
  ;

accessor_block
  : add_handler_accessor_block
  | get_accessor_block
  | raise_event_accessor_block
  | remove_handler_accessor_block
  | set_accessor_block
  ;

add_handler_accessor_block
  : accessor_statement end_add_handler_statement
  ;

accessor_statement
  : add_handler_accessor_statement
  | get_accessor_statement
  | raise_event_accessor_statement
  | remove_handler_accessor_statement
  | set_accessor_statement
  ;

add_handler_accessor_statement
  : 'AddHandler'
  ;

get_accessor_statement
  : 'Get'
  ;

raise_event_accessor_statement
  : 'RaiseEvent'
  ;

remove_handler_accessor_statement
  : 'RemoveHandler'
  ;

set_accessor_statement
  : 'Set'
  ;

get_accessor_block
  : accessor_statement end_get_statement
  ;

raise_event_accessor_block
  : accessor_statement end_raise_event_statement
  ;

remove_handler_accessor_block
  : accessor_statement end_remove_handler_statement
  ;

set_accessor_block
  : accessor_statement end_set_statement
  ;

field_declaration
  : attribute_list* modifier* variable_declarator (',' variable_declarator)*
  ;

variable_declarator
  : modified_identifier (',' modified_identifier)* as_clause? equals_value?
  ;

incomplete_member
  : attribute_list* modifier* identifier_token?
  ;

inherits_or_implements_statement
  : implements_statement
  | inherits_statement
  ;

implements_statement
  : 'Implements' type (',' type)*
  ;

inherits_statement
  : 'Inherits' type (',' type)*
  ;

method_base
  : accessor_statement
  | declare_statement
  | delegate_statement
  | event_statement
  | lambda_header
  | method_statement
  | operator_statement
  | property_statement
  | sub_new_statement
  ;

declare_statement
  : declare_function_statement
  | declare_sub_statement
  ;

declare_function_statement
  : 'Declare' ('Ansi' | 'Unicode' | 'Auto')? 'Function' identifier_token 'Lib' literal_expression 'Alias'? literal_expression? simple_as_clause?
  ;

literal_expression
  : 'False'
  | 'Nothing'
  | 'True'
  | character_literal_token
  | date_literal_token
  | decimal_literal_token
  | floating_literal_token
  | integer_literal_token
  | string_literal_token
  ;

declare_sub_statement
  : 'Declare' ('Ansi' | 'Unicode' | 'Auto')? 'Sub' identifier_token 'Lib' literal_expression 'Alias'? literal_expression? simple_as_clause?
  ;

delegate_statement
  : delegate_function_statement
  | delegate_sub_statement
  ;

delegate_function_statement
  : 'Delegate' 'Function' identifier_token type_parameter_list? simple_as_clause?
  ;

type_parameter_list
  : '(' 'Of' type_parameter (',' type_parameter)* ')'
  ;

type_parameter
  : 'In'? identifier_token type_parameter_constraint_clause?
  | 'Out'? identifier_token type_parameter_constraint_clause?
  ;

type_parameter_constraint_clause
  : type_parameter_multiple_constraint_clause
  | type_parameter_single_constraint_clause
  ;

type_parameter_multiple_constraint_clause
  : 'As' '{' constraint (',' constraint)* '}'
  ;

constraint
  : special_constraint
  | type_constraint
  ;

special_constraint
  : class_constraint
  | new_constraint
  | structure_constraint
  ;

class_constraint
  : 'Class'
  ;

new_constraint
  : 'New'
  ;

structure_constraint
  : 'Structure'
  ;

type_constraint
  : type
  ;

type_parameter_single_constraint_clause
  : 'As' constraint
  ;

delegate_sub_statement
  : 'Delegate' 'Sub' identifier_token type_parameter_list? simple_as_clause?
  ;

lambda_header
  : function_lambda_header
  | sub_lambda_header
  ;

function_lambda_header
  : 'Function' simple_as_clause?
  ;

sub_lambda_header
  : 'Sub' simple_as_clause?
  ;

method_statement
  : function_statement
  | sub_statement
  ;

function_statement
  : 'Function' identifier_token type_parameter_list? simple_as_clause? handles_clause? implements_clause?
  ;

handles_clause
  : 'Handles' handles_clause_item (',' handles_clause_item)*
  ;

handles_clause_item
  : event_container '.' identifier_name
  ;

event_container
  : keyword_event_container
  | with_events_event_container
  | with_events_property_event_container
  ;

keyword_event_container
  : 'Me'
  | 'MyBase'
  | 'MyClass'
  ;

with_events_event_container
  : identifier_token
  ;

with_events_property_event_container
  : with_events_event_container '.' identifier_name
  ;

sub_statement
  : 'Sub' identifier_token type_parameter_list? simple_as_clause? handles_clause? implements_clause?
  ;

operator_statement
  : attribute_list* modifier* 'Operator' ('CType' | 'IsTrue' | 'IsFalse' | 'Not' | '+' | '-' | '*' | '/' | '^' | '\\' | '&' | '<<' | '>>' | 'Mod' | 'Or' | 'Xor' | 'And' | 'Like' | '=' | '<>' | '<' | '<=' | '>=' | '>') parameter_list? simple_as_clause?
  ;

property_statement
  : attribute_list* modifier* 'Property' identifier_token parameter_list? as_clause? equals_value? implements_clause?
  ;

sub_new_statement
  : attribute_list* modifier* 'Sub' 'New' parameter_list?
  ;

method_block_base
  : accessor_block
  | constructor_block
  | method_block
  | operator_block
  ;

constructor_block
  : sub_new_statement statement* end_sub_statement
  ;

method_block
  : function_block
  | sub_block
  ;

function_block
  : method_statement end_function_statement
  ;

sub_block
  : method_statement end_sub_statement
  ;

operator_block
  : operator_statement statement* end_operator_statement
  ;

namespace_block
  : namespace_statement statement* end_namespace_statement
  ;

namespace_statement
  : 'Namespace' name
  ;

property_block
  : property_statement accessor_block* end_property_statement
  ;

type_block
  : class_block
  | interface_block
  | module_block
  | structure_block
  ;

class_block
  : class_statement inherits_statement* implements_statement* statement* end_class_statement
  ;

class_statement
  : attribute_list* modifier* 'Class' identifier_token type_parameter_list?
  ;

interface_block
  : interface_statement inherits_statement* implements_statement* statement* end_interface_statement
  ;

interface_statement
  : attribute_list* modifier* 'Interface' identifier_token type_parameter_list?
  ;

module_block
  : module_statement inherits_statement* implements_statement* statement* end_module_statement
  ;

module_statement
  : attribute_list* modifier* 'Module' identifier_token type_parameter_list?
  ;

structure_block
  : structure_statement inherits_statement* implements_statement* statement* end_structure_statement
  ;

structure_statement
  : attribute_list* modifier* 'Structure' identifier_token type_parameter_list?
  ;

type_statement
  : class_statement
  | interface_statement
  | module_statement
  | structure_statement
  ;

do_statement
  : 'Do' while_or_until_clause?
  ;

while_or_until_clause
  : until_clause
  | while_clause
  ;

until_clause
  : 'Until' expression
  ;

while_clause
  : 'While' expression
  ;

else_if_statement
  : 'ElseIf' expression 'Then'?
  ;

else_statement
  : 'Else'
  ;

empty_statement
  : empty_token
  ;

executable_statement
  : add_remove_handler_statement
  | assignment_statement
  | call_statement
  | continue_statement
  | do_loop_block
  | erase_statement
  | error_statement
  | exit_statement
  | expression_statement
  | for_or_for_each_block
  | go_to_statement
  | label_statement
  | local_declaration_statement
  | multi_line_if_block
  | on_error_go_to_statement
  | on_error_resume_next_statement
  | print_statement
  | raise_event_statement
  | re_dim_statement
  | resume_statement
  | return_statement
  | select_block
  | single_line_if_statement
  | stop_or_end_statement
  | sync_lock_block
  | throw_statement
  | try_block
  | using_block
  | while_block
  | with_block
  | yield_statement
  ;

add_remove_handler_statement
  : add_handler_statement
  | remove_handler_statement
  ;

add_handler_statement
  : 'AddHandler' expression ',' expression
  ;

remove_handler_statement
  : 'RemoveHandler' expression ',' expression
  ;

assignment_statement
  : expression ('=' | '+=' | '-=' | '*=' | '/=' | '\=' | '^=' | '<<=' | '>>=' | '&=') expression
  ;

call_statement
  : 'Call' expression
  ;

continue_statement
  : continue_do_statement
  | continue_for_statement
  | continue_while_statement
  ;

continue_do_statement
  : 'Continue' 'For'
  ;

continue_for_statement
  : 'Continue' 'While'
  ;

continue_while_statement
  : 'Continue' 'Do'
  ;

do_loop_block
  : do_statement statement* loop_statement
  ;

loop_statement
  : 'Loop' while_or_until_clause?
  ;

erase_statement
  : 'Erase' expression (',' expression)*
  ;

error_statement
  : 'Error' expression
  ;

exit_statement
  : exit_do_statement
  | exit_for_statement
  | exit_function_statement
  | exit_operator_statement
  | exit_property_statement
  | exit_select_statement
  | exit_sub_statement
  | exit_try_statement
  | exit_while_statement
  ;

exit_do_statement
  : 'Exit' 'Do'
  ;

exit_for_statement
  : 'Exit' 'For'
  ;

exit_function_statement
  : 'Exit' 'Function'
  ;

exit_operator_statement
  : 'Exit' 'Operator'
  ;

exit_property_statement
  : 'Exit' 'Property'
  ;

exit_select_statement
  : 'Exit' 'Select'
  ;

exit_sub_statement
  : 'Exit' 'Sub'
  ;

exit_try_statement
  : 'Exit' 'Try'
  ;

exit_while_statement
  : 'Exit' 'While'
  ;

expression_statement
  : expression
  ;

for_or_for_each_block
  : for_block
  | for_each_block
  ;

for_block
  : for_statement statement* next_statement?
  ;

for_statement
  : 'For' (expression | variable_declarator) '=' expression 'To' expression for_step_clause?
  ;

for_step_clause
  : 'Step' expression
  ;

next_statement
  : 'Next' (expression (',' expression)*)?
  ;

for_each_block
  : for_each_statement statement* next_statement?
  ;

for_each_statement
  : 'For' 'Each' (expression | variable_declarator) 'In' expression
  ;

go_to_statement
  : 'GoTo' label
  ;

label
  : identifier_label
  | next_label
  | numeric_label
  ;

identifier_label
  : identifier_token
  ;

next_label
  : 'Next'
  ;

numeric_label
  : integer_literal_token
  ;

label_statement
  : identifier_token ':'
  | integer_literal_token ':'
  ;

local_declaration_statement
  : modifier* variable_declarator (',' variable_declarator)*
  ;

multi_line_if_block
  : if_statement statement* else_if_block* else_block? end_if_statement
  ;

if_statement
  : 'If' expression 'Then'?
  ;

else_if_block
  : else_if_statement statement*
  ;

else_block
  : else_statement statement*
  ;

on_error_go_to_statement
  : on_error_go_to_label_statement
  | on_error_go_to_minus_one_statement
  | on_error_go_to_zero_statement
  ;

on_error_go_to_label_statement
  : 'On' 'Error' 'GoTo' '-'? next_label
  ;

on_error_go_to_minus_one_statement
  : 'On' 'Error' 'GoTo' '-'? numeric_label
  ;

on_error_go_to_zero_statement
  : 'On' 'Error' 'GoTo' '-'? identifier_label
  ;

on_error_resume_next_statement
  : 'On' 'Error' 'Resume' 'Next'
  ;

print_statement
  : '?' expression
  ;

raise_event_statement
  : 'RaiseEvent' identifier_name argument_list?
  ;

re_dim_statement
  : 'ReDim' 'Preserve'? (redim_clause (',' redim_clause)*)?
  ;

redim_clause
  : expression argument_list
  ;

resume_statement
  : resume_label_statement
  | resume_next_statement
  | resume_statement
  ;

resume_label_statement
  : 'Resume' numeric_label?
  ;

resume_next_statement
  : 'Resume' next_label?
  ;

resume_statement
  : 'Resume' identifier_label?
  ;

return_statement
  : 'Return' expression?
  ;

select_block
  : select_statement case_block* end_select_statement
  ;

select_statement
  : 'Select' 'Case'? expression
  ;

case_block
  : case_block
  | case_else_block
  ;

case_block
  : case_statement statement*
  ;

case_else_block
  : case_statement statement*
  ;

single_line_if_statement
  : 'If' expression 'Then' statement* single_line_else_clause?
  ;

single_line_else_clause
  : 'Else' statement*
  ;

stop_or_end_statement
  : end_statement
  | stop_statement
  ;

end_statement
  : 'End'
  ;

stop_statement
  : 'Stop'
  ;

sync_lock_block
  : sync_lock_statement statement* end_sync_lock_statement
  ;

sync_lock_statement
  : 'SyncLock' expression
  ;

throw_statement
  : 'Throw' expression?
  ;

try_block
  : try_statement statement* catch_block* finally_block? end_try_statement
  ;

try_statement
  : 'Try'
  ;

catch_block
  : catch_statement statement*
  ;

finally_block
  : finally_statement statement*
  ;

finally_statement
  : 'Finally'
  ;

using_block
  : using_statement statement* end_using_statement
  ;

using_statement
  : 'Using' expression? (variable_declarator (',' variable_declarator)*)?
  ;

while_block
  : while_statement statement* end_while_statement
  ;

while_statement
  : 'While' expression
  ;

with_block
  : with_statement statement* end_with_statement
  ;

with_statement
  : 'With' expression
  ;

yield_statement
  : 'Yield' expression
  ;

for_or_for_each_statement
  : for_each_statement
  | for_statement
  ;

expression
  : aggregation
  | await_expression
  | binary_conditional_expression
  | binary_expression
  | cast_expression
  | collection_initializer
  | conditional_access_expression
  | event_container
  | get_type_expression
  | get_xml_namespace_expression
  | instance_expression
  | interpolated_string_expression
  | into_variable_expression
  | invocation_expression
  | label
  | lambda_expression
  | literal_expression
  | member_access_expression
  | mid_expression
  | name_of_expression
  | new_expression
  | parenthesized_expression
  | predefined_cast_expression
  | query_expression
  | ternary_conditional_expression
  | tuple_expression
  | type
  | type_of_expression
  | unary_expression
  | xml_member_access_expression
  | xml_node
  ;

aggregation
  : function_aggregation
  | group_aggregation
  ;

function_aggregation
  : identifier_token '('? expression? ')'?
  ;

group_aggregation
  : 'Group'
  ;

await_expression
  : 'Await' expression
  ;

binary_conditional_expression
  : 'If' '(' expression ',' expression ')'
  ;

binary_expression
  : add_expression
  | and_also_expression
  | and_expression
  | concatenate_expression
  | divide_expression
  | equals_expression
  | exclusive_or_expression
  | exponentiate_expression
  | greater_than_expression
  | greater_than_or_equal_expression
  | integer_divide_expression
  | is_expression
  | is_not_expression
  | left_shift_expression
  | less_than_expression
  | less_than_or_equal_expression
  | like_expression
  | modulo_expression
  | multiply_expression
  | not_equals_expression
  | or_else_expression
  | or_expression
  | right_shift_expression
  | subtract_expression
  ;

add_expression
  : expression '+' expression
  ;

and_also_expression
  : expression 'AndAlso' expression
  ;

and_expression
  : expression 'And' expression
  ;

concatenate_expression
  : expression '>>' expression
  ;

divide_expression
  : expression '/' expression
  ;

equals_expression
  : expression '<>' expression
  ;

exclusive_or_expression
  : expression 'Xor' expression
  ;

exponentiate_expression
  : expression '^' expression
  ;

greater_than_expression
  : expression 'Is' expression
  ;

greater_than_or_equal_expression
  : expression '>=' expression
  ;

integer_divide_expression
  : expression '\\' expression
  ;

is_expression
  : expression 'IsNot' expression
  ;

is_not_expression
  : expression 'Like' expression
  ;

left_shift_expression
  : expression 'Mod' expression
  ;

less_than_expression
  : expression '<=' expression
  ;

less_than_or_equal_expression
  : expression '>' expression
  ;

like_expression
  : expression '&' expression
  ;

modulo_expression
  : expression '=' expression
  ;

multiply_expression
  : expression '*' expression
  ;

not_equals_expression
  : expression '<' expression
  ;

or_else_expression
  : expression 'OrElse' expression
  ;

or_expression
  : expression 'Or' expression
  ;

right_shift_expression
  : expression '<<' expression
  ;

subtract_expression
  : expression '-' expression
  ;

cast_expression
  : c_type_expression
  | direct_cast_expression
  | try_cast_expression
  ;

c_type_expression
  : 'CType' '(' expression ',' type ')'
  ;

direct_cast_expression
  : 'DirectCast' '(' expression ',' type ')'
  ;

try_cast_expression
  : 'TryCast' '(' expression ',' type ')'
  ;

conditional_access_expression
  : expression? '?' expression
  ;

get_type_expression
  : 'GetType' '(' type ')'
  ;

get_xml_namespace_expression
  : 'GetXmlNamespace' '(' xml_prefix_name? ')'
  ;

xml_prefix_name
  : xml_name_token
  ;

instance_expression
  : me_expression
  | my_base_expression
  | my_class_expression
  ;

me_expression
  : 'Me'
  ;

my_base_expression
  : 'MyBase'
  ;

my_class_expression
  : 'MyClass'
  ;

interpolated_string_expression
  : '$"' interpolated_string_content* '"'
  ;

interpolated_string_content
  : interpolated_string_text
  | interpolation
  ;

interpolated_string_text
  : interpolated_string_text_token
  ;

interpolation
  : '{' expression interpolation_alignment_clause? interpolation_format_clause? '}'
  ;

interpolation_alignment_clause
  : ',' expression
  ;

interpolation_format_clause
  : ':' interpolated_string_text_token
  ;

into_variable_expression
  : expression 'Into' identifier_name
  ;

invocation_expression
  : expression? argument_list?
  ;

lambda_expression
  : multi_line_lambda_expression
  | single_line_lambda_expression
  ;

multi_line_lambda_expression
  : multi_line_function_lambda_expression
  | multi_line_sub_lambda_expression
  ;

multi_line_function_lambda_expression
  : statement* end_sub_statement
  ;

multi_line_sub_lambda_expression
  : statement* end_function_statement
  ;

single_line_lambda_expression
  : lambda_header (expression | statement)
  ;

member_access_expression
  : dictionary_access_expression
  | simple_member_access_expression
  ;

dictionary_access_expression
  : expression? '!' generic_name
  ;

simple_member_access_expression
  : expression? '.' identifier_name
  ;

mid_expression
  : identifier_token argument_list
  ;

name_of_expression
  : 'NameOf' '(' expression ')'
  ;

parenthesized_expression
  : '(' expression ')'
  ;

predefined_cast_expression
  : 'CBool' '(' expression ')'
  | 'CByte' '(' expression ')'
  | 'CChar' '(' expression ')'
  | 'CDate' '(' expression ')'
  | 'CDbl' '(' expression ')'
  | 'CDec' '(' expression ')'
  | 'CInt' '(' expression ')'
  | 'CLng' '(' expression ')'
  | 'CObj' '(' expression ')'
  | 'CSByte' '(' expression ')'
  | 'CShort' '(' expression ')'
  | 'CSng' '(' expression ')'
  | 'CStr' '(' expression ')'
  | 'CUInt' '(' expression ')'
  | 'CULng' '(' expression ')'
  | 'CUShort' '(' expression ')'
  ;

query_expression
  : query_clause*
  ;

query_clause
  : aggregate_clause
  | distinct_clause
  | from_clause
  | group_by_clause
  | join_clause
  | let_clause
  | order_by_clause
  | partition_clause
  | partition_while_clause
  | select_clause
  | where_clause
  ;

aggregate_clause
  : 'Aggregate' collection_range_variable (',' collection_range_variable)* query_clause* 'Into' aggregation_range_variable (',' aggregation_range_variable)*
  ;

collection_range_variable
  : modified_identifier simple_as_clause? 'In' expression
  ;

aggregation_range_variable
  : variable_name_equals? aggregation
  ;

variable_name_equals
  : modified_identifier simple_as_clause? '='
  ;

distinct_clause
  : 'Distinct'
  ;

from_clause
  : 'From' collection_range_variable (',' collection_range_variable)*
  ;

group_by_clause
  : 'Group' expression_range_variable (',' expression_range_variable)* 'By' expression_range_variable (',' expression_range_variable)* 'Into' aggregation_range_variable (',' aggregation_range_variable)*
  ;

expression_range_variable
  : variable_name_equals? expression
  ;

join_clause
  : group_join_clause
  | simple_join_clause
  ;

group_join_clause
  : 'Group' 'Join' collection_range_variable (',' collection_range_variable)* join_clause* 'On' join_condition ('And' join_condition)* 'Into' aggregation_range_variable (',' aggregation_range_variable)*
  ;

join_condition
  : expression 'Equals' expression
  ;

simple_join_clause
  : 'Join' collection_range_variable (',' collection_range_variable)* join_clause* 'On' join_condition ('And' join_condition)*
  ;

let_clause
  : 'Let' expression_range_variable (',' expression_range_variable)*
  ;

order_by_clause
  : 'Order' 'By' ordering (',' ordering)*
  ;

ordering
  : ascending_ordering
  | descending_ordering
  ;

ascending_ordering
  : expression 'Ascending'?
  ;

descending_ordering
  : expression 'Descending'?
  ;

partition_clause
  : skip_clause
  | take_clause
  ;

skip_clause
  : 'Skip' expression
  ;

take_clause
  : 'Take' expression
  ;

partition_while_clause
  : skip_while_clause
  | take_while_clause
  ;

skip_while_clause
  : 'Skip' 'While' expression
  ;

take_while_clause
  : 'Take' 'While' expression
  ;

select_clause
  : 'Select' expression_range_variable (',' expression_range_variable)*
  ;

where_clause
  : 'Where' expression
  ;

ternary_conditional_expression
  : 'If' '(' expression ',' expression ',' expression ')'
  ;

tuple_expression
  : '(' simple_argument (',' simple_argument)+ ')'
  ;

type_of_expression
  : type_of_is_expression
  | type_of_is_not_expression
  ;

type_of_is_expression
  : 'TypeOf' expression 'Is' (expression | type_argument_list)
  ;

type_of_is_not_expression
  : 'TypeOf' expression 'IsNot' (expression | type_argument_list)
  ;

unary_expression
  : address_of_expression
  | not_expression
  | unary_minus_expression
  | unary_plus_expression
  ;

address_of_expression
  : 'AddressOf' expression
  ;

not_expression
  : 'Not' expression
  ;

unary_minus_expression
  : '-' expression
  ;

unary_plus_expression
  : '+' expression
  ;

xml_member_access_expression
  : expression? '.' ('.' | '@')? '.'? xml_node
  ;

type
  : array_type
  | name
  | nullable_type
  | predefined_type
  | tuple_type
  ;

array_type
  : type array_rank_specifier*
  ;

nullable_type
  : type '?'
  ;

predefined_type
  : 'Boolean'
  | 'Byte'
  | 'Char'
  | 'Date'
  | 'Decimal'
  | 'Double'
  | 'Integer'
  | 'Long'
  | 'Object'
  | 'SByte'
  | 'Short'
  | 'Single'
  | 'String'
  | 'UInteger'
  | 'ULong'
  | 'UShort'
  ;

tuple_type
  : '(' tuple_element (',' tuple_element)+ ')'
  ;

tuple_element
  : named_tuple_element
  | typed_tuple_element
  ;

named_tuple_element
  : identifier_token simple_as_clause?
  ;

typed_tuple_element
  : type
  ;

name
  : cref_operator_reference
  | global_name
  | qualified_cref_operator_reference
  | qualified_name
  | simple_name
  ;

cref_operator_reference
  : 'Operator' ('CType' | 'IsTrue' | 'IsFalse' | 'Not' | '+' | '-' | '*' | '/' | '^' | '\\' | '&' | '<<' | '>>' | 'Mod' | 'Or' | 'Xor' | 'And' | 'Like' | '=' | '<>' | '<' | '<=' | '>=' | '>')
  ;

global_name
  : 'Global'
  ;

qualified_cref_operator_reference
  : name '.' cref_operator_reference
  ;

xml_node
  : base_xml_attribute
  | xml_bracketed_name
  | xml_c_data_section
  | xml_comment
  | xml_document
  | xml_element
  | xml_element_end_tag
  | xml_element_start_tag
  | xml_embedded_expression
  | xml_empty_element
  | xml_name
  | xml_prefix_name
  | xml_processing_instruction
  | xml_string
  | xml_text
  ;

base_xml_attribute
  : xml_attribute
  | xml_cref_attribute
  | xml_name_attribute
  ;

xml_cref_attribute
  : xml_name '=' ('"' | '\'') cref_reference ('"' | '\'')
  ;

xml_name
  : xml_prefix? xml_name_token
  ;

xml_prefix
  : xml_name_token ':'
  ;

cref_reference
  : type cref_signature? simple_as_clause?
  ;

cref_signature
  : '(' (cref_signature_part (',' cref_signature_part)*)? ')'
  ;

cref_signature_part
  : 'ByRef'? type?
  | 'ByVal'? type?
  ;

xml_name_attribute
  : xml_name '=' ('"' | '\'') identifier_name ('"' | '\'')
  ;

xml_bracketed_name
  : '<' xml_name '>'
  ;

xml_c_data_section
  : '<![CDATA[' xml_text_token* ']]>'
  ;

xml_comment
  : '<!--' xml_text_token* '-->'
  ;

xml_document
  : xml_declaration xml_node* xml_node xml_node*
  ;

xml_declaration
  : '<?' 'xml' xml_declaration_option xml_declaration_option? xml_declaration_option? '?>'
  ;

xml_declaration_option
  : xml_name_token '=' xml_string
  ;

xml_string
  : '"' (xml_text_token)* ('"' | '\'')
  | '\'' (xml_text_token)* ('"' | '\'')
  ;

xml_element
  : xml_element_start_tag xml_node* xml_element_end_tag
  ;

xml_element_start_tag
  : '<' xml_node xml_node* '>'
  ;

xml_element_end_tag
  : '</' xml_name? '>'
  ;

xml_embedded_expression
  : '<%=' expression '%>'
  ;

xml_empty_element
  : '<' xml_node xml_node* '/>'
  ;

xml_processing_instruction
  : '<?' xml_name_token xml_text_token* '?>'
  ;

xml_text
  : xml_text_token*
  ;

structured_trivia
  : directive_trivia
  | documentation_comment_trivia
  | skipped_tokens_trivia
  ;

directive_trivia
  : bad_directive_trivia
  | const_directive_trivia
  | disable_warning_directive_trivia
  | else_directive_trivia
  | enable_warning_directive_trivia
  | end_external_source_directive_trivia
  | end_if_directive_trivia
  | end_region_directive_trivia
  | external_checksum_directive_trivia
  | external_source_directive_trivia
  | if_directive_trivia
  | reference_directive_trivia
  | region_directive_trivia
  ;

bad_directive_trivia
  : '#'
  ;

const_directive_trivia
  : '#' 'Const' identifier_token '=' expression
  ;

disable_warning_directive_trivia
  : '#' 'Disable' 'Warning' (identifier_name (',' identifier_name)*)?
  ;

else_directive_trivia
  : '#' 'Else'
  ;

enable_warning_directive_trivia
  : '#' 'Enable' 'Warning' (identifier_name (',' identifier_name)*)?
  ;

end_external_source_directive_trivia
  : '#' 'End' 'ExternalSource'
  ;

end_if_directive_trivia
  : '#' 'End' 'If'
  ;

end_region_directive_trivia
  : '#' 'End' 'Region'
  ;

external_checksum_directive_trivia
  : '#' 'ExternalChecksum' '(' string_literal_token ',' string_literal_token ',' string_literal_token ')'
  ;

external_source_directive_trivia
  : '#' 'ExternalSource' '(' string_literal_token ',' integer_literal_token ')'
  ;

if_directive_trivia
  : else_if_directive_trivia
  | if_directive_trivia
  ;

else_if_directive_trivia
  : 'Else'? 'ElseIf' expression 'Then'?
  ;

if_directive_trivia
  : 'Else'? 'If' expression 'Then'?
  ;

reference_directive_trivia
  : '#' 'R' string_literal_token
  ;

region_directive_trivia
  : '#' 'Region' string_literal_token
  ;

documentation_comment_trivia
  : xml_node*
  ;

skipped_tokens_trivia
  : syntax_token*
  ;

modifier
  : 'Async'
  | 'Const'
  | 'Default'
  | 'Dim'
  | 'Friend'
  | 'Iterator'
  | 'MustInherit'
  | 'MustOverride'
  | 'Narrowing'
  | 'NotInheritable'
  | 'NotOverridable'
  | 'Overloads'
  | 'Overridable'
  | 'Overrides'
  | 'Partial'
  | 'Private'
  | 'Protected'
  | 'Public'
  | 'ReadOnly'
  | 'Shadows'
  | 'Shared'
  | 'Static'
  | 'Widening'
  | 'WithEvents'
  | 'WriteOnly'
  ;

syntax_token
  : character_literal_token
  | date_literal_token
  | decimal_literal_token
  | floating_literal_token
  | identifier_token
  | integer_literal_token
  | interpolated_string_text_token
  | keyword
  | punctuation
  | string_literal_token
  | xml_name_token
  | xml_text_token
  ;

punctuation
  : /* see lexical specification */
  ;

empty_token
  : /* see lexical specification */
  ;

character_literal_token
  : /* see lexical specification */
  ;

date_literal_token
  : /* see lexical specification */
  ;

decimal_literal_token
  : /* see lexical specification */
  ;

floating_literal_token
  : /* see lexical specification */
  ;

identifier_token
  : /* see lexical specification */
  ;

integer_literal_token
  : /* see lexical specification */
  ;

interpolated_string_text_token
  : /* see lexical specification */
  ;

keyword
  : /* see lexical specification */
  ;

string_literal_token
  : /* see lexical specification */
  ;

syntax_trivia
  : /* see lexical specification */
  ;

xml_name_token
  : /* see lexical specification */
  ;

xml_text_token
  : /* see lexical specification */
  ;
