gamma.svg: gamma.gpi gamma.data factorials.data
	gnuplot $< > $@
gamma.data: main.exe
	mono $< >$@
main.exe: main.cs sfuns.dll
	mcs $< -target:exe -out:$@ $(addprefix -reference:,$(filter %.dll,$^))

sfuns.dll: gamma.cs erf.cs
	mcs $^ -target:library -out:$@
factorials.data:sfuns.dll
	>$@
	echo 0 1 >>$@
clean:
	rm -f factorials.data sfuns.dll main.exe gamma.data gamma.svg
