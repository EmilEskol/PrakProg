DIR = ../../matlib
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
OUTPUTS=$(addprefix -output:,$(filter %.data,$^))
MKLIBF = mcs $^ -target:library -out:./$@
MKLIB = mcs $< -target:library -out:$@
MKEXE = mcs $< -target:exe -out:$@
MKDATA = mono $< > $@
DATA = Data.data LineterpIntegTests.data LineterpTests.data qSpline1.data qSpline2.data
DATA2 = qSpline3.data qData.data

Task: Out.txt SplineTest.svg qSpline.svg

Out.txt: main.exe $(DATA) $(DATA2)
	mono $< -input:Input.txt $(OUTPUTS) > $@
main.exe: main.cs Spline.dll qSpline.dll matlib.dll
	$(MKEXE) $(DLLS)
matlib.dll: $(DIR)/IOputs.cs $(DIR)/matrix/vector.cs $(DIR)/matrix/matrix.cs $(DIR)/genlist.cs
	$(MKLIBF)
Spline.dll: Spline.cs
	$(MKLIB)
qSpline.dll:qSpline.cs Spline.dll matlib.dll
	$(MKLIB) $(DLLS)

SplineTest.svg: SplineTest.gpi Data.data LineterpIntegTests.data LineterpTests.data
	gnuplot $< > $@
Data.data:
LineterpIntegTests.data:
LineterpTests.data:

qSpline.svg:qSpline.gpi qSpline1.data qSpline2.data qSpline3.data
	gnuplot $< > $@
qSpline1.data:
qSpline2.data:
qSpline3.data:
qData.data:

clean:
	rm -f Out.txt *.exe *.dll *.data *.svg
