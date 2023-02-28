using System;
using static System.Console;
using System.Threading.Tasks;

class parallel{
	static void Main(string[] args){
	double sum=0;
	int nTerms=(int) 1e8;
	foreach(var arg in args){
		var words = arg.Split(':');
		if(words[0]=="-terms") nTerms = (int)float.Parse(words[1]);
	}
	
	Parallel.For(1,nTerms+1, delegate(int i){sum+=1.0/i;});
	WriteLine($"Parallel sum={sum}");
	}
}
