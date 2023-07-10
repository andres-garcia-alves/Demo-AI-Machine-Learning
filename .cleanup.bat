@echo off

echo.
echo Deleting folders 'bin' and 'obj' in projects...
echo.

echo -^> "Image-Classification-Console\bin"
rd "Image-Classification-Console\bin\" /Q /S 2>nul

echo -^> "Image-Classification-Console\obj"
rd "Image-Classification-Console\obj\" /Q /S 2>nul

echo -^> "Image-Classification-Entities\bin"
rd "Image-Classification-Entities\bin\" /Q /S 2>nul

echo -^> "Image-Classification-Entities\obj"
rd Image-Classification-Entities\obj\ /Q /S 2>nul

echo -^> "Image-Classification-WinForms\bin"
rd Image-Classification-WinForms\bin\ /Q /S 2>nul

echo -^> "Image-Classification-WinForms\obj"
rd Image-Classification-WinForms\obj\ /Q /S 2>nul

echo -^> "Values-Prediction-ByHand-Console\bin"
rd Values-Prediction-ByHand-Console\bin\ /S /Q 2>nul

echo -^> "Values-Prediction-ByHand-Console\obj"
rd Values-Prediction-ByHand-Console\obj\ /S /Q 2>nul

echo -^> "Values-Prediction-ModelBuilder-Console\bin"
rd Values-Prediction-ModelBuilder-Console\bin\ /S /Q 2>nul

echo -^> "Values-Prediction-ModelBuilder-Console\obj"
rd Values-Prediction-ModelBuilder-Console\obj\ /S /Q 2>nul

echo.
echo Deleting generated models...
echo.

echo -^> "Models\image-classification-model.zip"
del Models\image-classification-model.zip /Q 1>nul 2>nul

echo.
echo Clean-up completed. Press any key to exit.
pause > nul
