
DIR = ../matlib
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
MKLIBF = mcs $^ -target:library -out:./$@
MKLIB = mcs $< -target:library -out:$@
MKEXE = mcs $< -target:exe -out:$@

TIME = time --portability --append --output $@
DATA = berrutSpline.data berrutData.data berrutSpline2.data berrutData2.data
DATA2 =berrutDataCos.data berrutSplineCos.data berrutSplineCos2.data\
	 berrutSplineCos3.data berrutSplineCos4.data
DATA3 = Convergence.data Convergence2.data Convergence3.data Convergence4.data
OUTPUTS=$(addprefix -output:,$(filter %.data,$(DATA)))
OUTPUTS2=$(addprefix -output:,$(filter %.data,$(DATA2)))
OUTPUTS3=$(addprefix -output:,$(filter %.data,$(DATA3)))


Task: Out.txt berrutSpline.svg berrutSplineCos.svg Convergence.svg

Out.txt: main.exe
	mono $< -threads:1 $(OUTPUTS) $(OUTPUTS2) $(OUTPUTS3) > $@
	$(TIME) mono $< -time:true -threads:1 -nPoints:200000 >> $@
	$(TIME) mono $< -time:true -threads:2 -nPoints:200000 >> $@
	$(TIME) mono $< -time:true -threads:3 -nPoints:200000 >> $@
	$(TIME) mono $< -time:true -threads:4 -nPoints:200000 >> $@
	$(TIME) mono $< -time:true -threads:1 -nPoints:2000 -nEvals:10000 >> $@
	$(TIME) mono $< -time:true -threads:4 -nPoints:2000 -nEvals:10000 >> $@

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
	rm -f Out.txt Time.txt *.exe *.dll *.data *.svg
