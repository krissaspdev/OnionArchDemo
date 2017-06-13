@echo off
for /D %%i in (*.Tests*) do (
    cd %%i
    dotnet test
    cd..
)
