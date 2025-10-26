When a `ReSharper feature` is seldom used and/or a developer needs documentation or when a developer defines their own shortcuts, consider creating a markdown file as shown below.

Place the markdown file in a folder like `C:\DotnetLand\Resharper`.

Setup and `External tool menu item` to easily access the markdown file from Visual Studio.

![Visual Studio Code](https://img.shields.io/badge/Visual%20Studio%20Code-0078d7.svg?style=for-the-badge&logo=visual-studio-code&logoColor=white) 

Will be needed to view the markdown file in Visual Studio. 

Create a new external tool in Visual Studio:

**Title**: `ReSharper Shortcuts`
**Command**: c:\users\\`username`\\AppData\Local\Programs\Microsoft VS Code\Code.exe
**Arguments**: `keyboardShortcuts.md`
**Initial Directory**: `C:\DotnetLand\ReSharper`


## Custom shortcuts for ReSharper

In the table below, Keyboard Reference links to the official ReSharper documentation for each shortcut.

> **Note**
> keyboard shortcuts below are the author's personal preferences and differ from default ReSharper keyboard shortcuts.

| Description        |   Shortcut    | Keyboard Reference
|:------------- |:-------------|:-------------|
| **Extract Interface**| <kbd>ctrl</kbd> + <kbd>O</kbd> + <kbd>G</kbd>| [ReSharper_ExtractInterface](https://www.jetbrains.com/help/resharper/Refactorings__Extract_Interface.html) |
| **Move Types into Matching Files**| <kbd>ctrl</kbd> + <kbd>M</kbd> + <kbd>J</kbd>| [ReSharper_MoveTypesIntoMatchingFiles](https://www.jetbrains.com/help/resharper/Refactorings__Move_Types_into_Matching_Files.html) |
| Extract Superclass| <kbd>ctrl</kbd> + <kbd>O</kbd> + <kbd>E</kbd> |[ReSharper_ExtractSuperclass](https://www.jetbrains.com/help/resharper/Refactorings__Extract_Superclass.html) |
| Change Signature| <kbd>ctrl</kbd> + <kbd>O</kbd> + <kbd>S</kbd>| [ReSharper_ChangeSignature](https://www.jetbrains.com/help/resharper/Refactorings__Change_Signature.html) |
| **Convert Anonymous to Named Type refactoring**| <kbd>ctrl</kbd> + <kbd>O</kbd> + <kbd>P</kbd> | [ReSharper_Anonymous2Declared](https://www.jetbrains.com/help/resharper/Refactorings__Convert_Anonymous_to_Named_Type.html) |
| Extract Method refactoring | <kbd>ctrl</kbd> + <kbd>O</kbd> <kbd>I</kbd> | [ReSharper_ExtractMethod](https://www.jetbrains.com/help/resharper/Refactorings__Extract_Method.html) |
| Generate Deconstructors | <kbd>ctrl</kbd> + <kbd>T</kbd> <kbd>Y</kbd> | [ReSharper_GenerateDeconstructor](https://www.jetbrains.com/help/resharper/Code_Generation_Deconstructors.html) |
| Copy Type refactoring | <kbd>ctrl</kbd> + <kbd>C</kbd> <kbd>T</kbd> | [ReSharper_CopyType](https://www.jetbrains.com/help/resharper/Refactorings__Copy_Type.html)  
| Rename file from solution explorer | <kbd>ctrl</kbd> + <kbd>R</kbd> + <kbd>R</kbd> | [ReSharper_Rename](https://www.jetbrains.com/help/resharper/Refactorings__Rename.html)
| Surround code fragments with templates | <kbd>ctrl</kbd> + <kbd>E</kbd> + <kbd>U</kbd> | [Surround code fragments](https://www.jetbrains.com/help/resharper/Templates__Applying_Templates__Surrounding_Code_Fragments_with_Templates.html)
| Razor live templates  | <kbd>ctrl</kbd> + <kbd>E</kbd> + <kbd>L</kbd> | [Create source code using live templates](https://www.jetbrains.com/help/resharper/Templates__Applying_Templates__Creating_Source_Code_Using_Live_Templates.html)
| Goto file| <kbd>ctrl</kbd> + <kbd>O</kbd>, <kbd>L</kbd> | [ReSharper_GotoFile](https://www.jetbrains.com/help/resharper/Navigation_and_Search__Go_to_File.html) |
| File Structure | <kbd>ctrl</kbd> + <kbd>alt</kbd> + + <kbd>F</kbd> | [ReSharper_ShowCodeStructure](https://www.jetbrains.com/help/resharper/Navigation_and_Search__Context_Dependent_Navigation.html) |
|Add new file | <kbd>ctrl</kbd> + <kbd>shift</kbd> + <kbd>A</kbd> |  |
| Search Everywhere | <kbd>ctrl</kbd> + <kbd>O</kbd> + <kbd>T</kbd> | [ReSharper_GotoType](https://www.jetbrains.com/help/resharper/Navigation_and_Search__Go_to_Type.html) |
| Find usages | <kbd>ctrl</kbd> + <kbd>T</kbd> + <kbd>Y</kbd> | [ReSharper_FindUsages](https://www.jetbrains.com/help/resharper/Resources__Navigation__Find_Usages.html) |
|Smart completion| <kbd>shift</kbd> + <kbd>alt</kbd> + <kbd>space</kbd> | [ReSharper_CompleteCodeSmarts](https://www.jetbrains.com/help/resharper/Coding_Assistance__Code_Completion__Smart.html) |

---

