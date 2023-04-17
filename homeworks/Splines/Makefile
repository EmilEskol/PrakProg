DIR = ../../matlib
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
OUTPUTS=$(addprefix -output:,$(filter %.data,$^))
MKLIBF = mcs $^ -target:library -out:./$@
MKLIB = mcs $< -target:library -out:$@
MKEXE = mcs $< -target:exe -out:$@
MKDATA = mono $< > $@

Task: Out.txt SplineTest.svg

Out.txt: main.exe Data.data LineterpIntegTests.data LineterpTests.data
	mono $< -input:Input.txt $(OUTPUTS) > $@
main.exe: main.cs Spline.dll qSpline.dll matlib.dll
	$(MKEXE) $(DLLS)
matlib.dll: $(DIR)/IOputs.cs $(DIR)/matrix/vector.cs
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

clean:
	rm -f Out.txt *.exe *.dll *.data *.svg
