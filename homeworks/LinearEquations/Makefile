DIR = ../../matlib
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
MKLIBF = mcs $(filter %.cs,$^) -target:library -out:./$@
MKLIB = mcs $< -target:library -out:$@

Task:Out.txt OutC.txt Out.times.data partC.svg
Out.txt: main.exe
	mono $< > $@
main.exe: main.cs matrix.dll QRGS.dll
	mcs $< -target:exe -out:$@ $(DLLS)

matrix.dll: $(DIR)/matrix/matrix.cs $(DIR)/matrix/vector.cs
	$(MKLIBF)

QRGS.dll: QRGS.cs matrix.dll
	$(MKLIB) $(DLLS)

#Part c
Out.times.data: main.exe
	>$@
	for N in $$(seq 100 200 1500); do\
		time --format "$$N	%e" --output $@ --append\
		mono $< -size:$$N ; done

OutC.txt:fitN.exe Out.times.data
	mono $< -input:Out.times.data -output:partCfit.data >$@

partCfit.data:fitN.exe

fitN.exe:fitN.cs matrix.dll matlib.dll
	mcs $< -target:exe -out:$@ $(DLLS)

matlib.dll: matrix.dll $(DIR)/IOputs.cs $(DIR)/genlist.cs $(DIR)/matrix/minimi.cs
	$(MKLIBF) $(DLLS)

partC.svg: partC.gpi Out.times.data partCfit.data
	gnuplot $< > $@

clean:
	rm -f Out.txt OutC.txt *.exe *.dll *.data *.svg
