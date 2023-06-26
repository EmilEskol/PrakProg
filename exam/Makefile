DIR = ../matlib
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
MKLIBF = mcs $^ -target:library -out:./$@
MKLIB = mcs $< -target:library -out:$@
MKEXE = mcs $< -target:exe -out:$@
DATA = berrutSpline.data berrutData.data berrutSpline2.data berrutData2.data
DATA2 =berrutDataCos.data berrutSplineCos.data berrutSplineCos2.data\
	 berrutSplineCos3.data berrutSplineCos4.data
DATA3 = Convergence.data
OUTPUTS=$(addprefix -output:,$(filter %.data,$(DATA)))
OUTPUTS2=$(addprefix -output:,$(filter %.data,$(DATA2)))
OUTPUTS3=$(addprefix -output:,$(filter %.data,$(DATA3)))


Task: Out.txt berrutSpline.svg berrutSplineCos.svg Convergence.svg

Out.txt: main.exe Input.txt
	mono $< -input:Input.txt $(OUTPUTS) $(OUTPUTS2) $(OUTPUTS3) > $@

main.exe: main.cs berrutSpline.dll matlib.dll
	$(MKEXE) $(DLLS)

matlib.dll: $(DIR)/IOputs.cs $(DIR)/matrix/vector.cs $(DIR)/matrix/matrix.cs $(DIR)/genlist.cs
	$(MKLIBF) $(DLLS)

berrutSpline.dll:BerrutSpline.cs matlib.dll
	$(MKLIB) $(DLLS)

berrutSpline.svg:berrutSpline.gpi $(DATA)
	gnuplot $< > $@
berrutSplineCos.svg:berrutSplineCos.gpi $(DATA2)
	gnuplot $< > $@
Convergence.svg:Convergence.gpi $(DATA3)
	gnuplot $< > $@

$(DATA) $(DATA2) $(DATA3): main.exe

clean:
	rm -f Out.txt *.exe *.dll *.data *.svg
