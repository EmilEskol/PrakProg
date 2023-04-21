DIR = ../../matlib
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
OUTPUTS=$(addprefix -output:,$(filter %.data,$^))
MKLIBF = mcs $^ -target:library -out:./$@
MKLIB = mcs $< -target:library -out:$@
MKEXE = mcs $< -target:exe -out:$@
MKDATA = mono $< > $@
DATA = Data.data LineterpIntegTests.data LineterpTests.data
OUTPUTS=$(addprefix -output:,$(filter %.data,$(DATA)))
DATA2 = qSpline1.data qSpline2.data qSpline3.data qSpline4.data qSpline4D.data qSpline4I.data qData.data
OUTPUTS2=$(addprefix -output:,$(filter %.data,$(DATA2)))

Task: Out.txt SplineTest.svg qSpline.svg

Out.txt: main.exe Input.txt
	mono $< -input:Input.txt $(OUTPUTS) $(OUTPUTS2)> $@

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


qSpline.svg:qSpline.gpi qSpline1.data qSpline2.data qSpline3.data
	gnuplot $< > $@

$(DATA) $(DATA2): main.exe

clean:
	rm -f Out.txt *.exe *.dll *.data *.svg
