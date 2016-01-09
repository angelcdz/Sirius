
SET ClientPath=C:\Program Files\Microsoft Dynamics CRM USD\USD\
SET AssemblyPath=%ClientPath%%3

IF NOT DEFINED BUILD_MACHINE (

   echo Copying Assemblies...
   IF NOT EXIST "%AssemblyPath%" MD "%AssemblyPath%"
    COPY %1 "%AssemblyPath%" /Y

   IF [%4] NEQ [] (
   echo Overwriting configuration...
      COPY %4 "%ClientPath%" /Y
   )

)