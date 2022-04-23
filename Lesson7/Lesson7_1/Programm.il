// Type: Lesson5_1.Program 
// Assembly: Lesson5_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D2070C55-A02D-419C-A547-E9F797483918
// Location: E:\Doc\VisualStudio\C#\GeekBrains\Lesson5\Lesson5_1\bin\Debug\net5.0\Lesson5_1.dll
// Sequence point data from E:\Doc\VisualStudio\C#\GeekBrains\Lesson5\Lesson5_1\bin\Debug\net5.0\Lesson5_1.pdb

.class private auto ansi beforefieldinit
  Lesson5_1.Program
    extends [System.Runtime]System.Object
{

  .method private hidebysig static void
    Main(
      string[] args
    ) cil managed
  {
    .entrypoint
    .maxstack 8

    // [14 9 - 14 10]
    IL_0000: nop

    // [15 13 - 15 36]
    IL_0001: call         string Lesson5_1.Program::AskString()
    IL_0006: call         void Lesson5_1.Program::WriteFile(string)
    IL_000b: nop

    // [16 13 - 16 28]
    IL_000c: ldc.i4.0
    IL_000d: call         void Lesson5_1.Program::PressAnyKey(int32)
    IL_0012: nop

    // [18 9 - 18 10]
    IL_0013: ret

  } // end of method Program::Main

  .method private hidebysig static string
    AskString() cil managed
  {
    .maxstack 2
    .locals init (
      [0] string stringTest,
      [1] bool V_1,
      [2] bool V_2,
      [3] string V_3
    )

    // [25 9 - 25 10]
    IL_0000: nop
    // start of loop, entry point: IL_0001

      // [29 13 - 29 14]
      IL_0001: nop

      // [30 17 - 30 110]
      IL_0002: ldstr        "Введите данные которые нужно записать в файл и нажмите клавишу <Enter>:"
      IL_0007: call         void [System.Console]System.Console::WriteLine(string)
      IL_000c: nop

      // [31 17 - 31 49]
      IL_000d: call         string [System.Console]System.Console::ReadLine()
      IL_0012: stloc.0      // stringTest

      // [33 17 - 33 44]
      IL_0013: ldloc.0      // stringTest
      IL_0014: callvirt     instance int32 [System.Runtime]System.String::get_Length()
      IL_0019: ldc.i4.0
      IL_001a: ceq
      IL_001c: stloc.1      // V_1

      IL_001d: ldloc.1      // V_1
      IL_001e: brfalse.s    IL_002d

      // [34 17 - 34 18]
      IL_0020: nop

      // [35 21 - 35 70]
      IL_0021: ldstr        "Ошибка! Вы ничего не ввели."
      IL_0026: call         void [System.Console]System.Console::WriteLine(string)
      IL_002b: nop

      // [36 17 - 36 18]
      IL_002c: nop

      // [38 13 - 38 14]
      IL_002d: nop

      // [38 15 - 38 46]
      IL_002e: ldloc.0      // stringTest
      IL_002f: callvirt     instance int32 [System.Runtime]System.String::get_Length()
      IL_0034: ldc.i4.0
      IL_0035: ceq
      IL_0037: stloc.2      // V_2

      IL_0038: ldloc.2      // V_2
      IL_0039: brtrue.s     IL_0001
    // end of loop

    // [40 13 - 40 31]
    IL_003b: ldloc.0      // stringTest
    IL_003c: stloc.3      // V_3
    IL_003d: br.s         IL_003f

    // [41 9 - 41 10]
    IL_003f: ldloc.3      // V_3
    IL_0040: ret

  } // end of method Program::AskString

  .method private hidebysig static void
    WriteFile(
      string stringToFile
    ) cil managed
  {
    .maxstack 2
    .locals init (
      [0] string fileName
    )

    // [48 9 - 48 10]
    IL_0000: nop

    // [49 13 - 49 42]
    IL_0001: ldstr        "test.txt"
    IL_0006: stloc.0      // fileName

    // [50 13 - 50 55]
    IL_0007: ldloc.0      // fileName
    IL_0008: ldarg.0      // stringToFile
    IL_0009: call         void [System.IO.FileSystem]System.IO.File::WriteAllText(string, string)
    IL_000e: nop

    // [51 13 - 51 65]
    IL_000f: ldstr        "Данные успешно записаны в файл"
    IL_0014: call         void [System.Console]System.Console::WriteLine(string)
    IL_0019: nop

    // [52 9 - 52 10]
    IL_001a: ret

  } // end of method Program::WriteFile

  .method public hidebysig static void
    PressAnyKey(
      int32 task
    ) cil managed
  {
    .maxstack 2
    .locals init (
      [0] int32 V_0,
      [1] int32 V_1
    )

    // [60 9 - 60 10]
    IL_0000: nop

    // [61 13 - 61 26]
    IL_0001: ldarg.0      // task
    IL_0002: stloc.1      // V_1

    IL_0003: ldloc.1      // V_1
    IL_0004: stloc.0      // V_0

    IL_0005: ldloc.0      // V_0
    IL_0006: brfalse.s    IL_0010
    IL_0008: br.s         IL_000a
    IL_000a: ldloc.0      // V_0
    IL_000b: ldc.i4.1
    IL_000c: beq.s        IL_002a
    IL_000e: br.s         IL_0044

    // [64 21 - 64 41]
    IL_0010: call         void [System.Console]System.Console::WriteLine()
    IL_0015: nop

    // [65 21 - 65 91]
    IL_0016: ldstr        "Для выхода из программы нажмите любую клавишу..."
    IL_001b: call         void [System.Console]System.Console::WriteLine(string)
    IL_0020: nop

    // [66 21 - 66 43]
    IL_0021: ldc.i4.1
    IL_0022: call         valuetype [System.Console]System.ConsoleKeyInfo [System.Console]System.Console::ReadKey(bool)
    IL_0027: pop

    // [67 21 - 67 27]
    IL_0028: br.s         IL_004d

    // [70 21 - 70 41]
    IL_002a: call         void [System.Console]System.Console::WriteLine()
    IL_002f: nop

    // [71 21 - 71 83]
    IL_0030: ldstr        "Для продолжения нажмите любую клавишу..."
    IL_0035: call         void [System.Console]System.Console::WriteLine(string)
    IL_003a: nop

    // [72 21 - 72 43]
    IL_003b: ldc.i4.1
    IL_003c: call         valuetype [System.Console]System.ConsoleKeyInfo [System.Console]System.Console::ReadKey(bool)
    IL_0041: pop

    // [73 21 - 73 27]
    IL_0042: br.s         IL_004d

    // [76 21 - 76 43]
    IL_0044: ldc.i4.1
    IL_0045: call         valuetype [System.Console]System.ConsoleKeyInfo [System.Console]System.Console::ReadKey(bool)
    IL_004a: pop

    // [77 21 - 77 27]
    IL_004b: br.s         IL_004d

    // [79 9 - 79 10]
    IL_004d: ret

  } // end of method Program::PressAnyKey

  .method public hidebysig specialname rtspecialname instance void
    .ctor() cil managed
  {
    .maxstack 8

    IL_0000: ldarg.0      // this
    IL_0001: call         instance void [System.Runtime]System.Object::.ctor()
    IL_0006: nop
    IL_0007: ret

  } // end of method Program::.ctor
} // end of class Lesson5_1.Program
