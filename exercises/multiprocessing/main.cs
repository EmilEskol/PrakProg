using System;
using System.Threading;
using static System.Math;
using static System.Console;



static class main{
	public class data {public int a, b;public double sumab;}
	public static void harm(object obj){
		data x = (data)obj;
		//WriteLine($"{Thread.CurrentThread.Name} a={x.a} b={x.b}");
		x.sumab=0;
		for(int i=x.a;i<x.b;i++)x.sumab+=1.0/i;
		//WriteLine($"{Thread.CurrentThread.Name} partialSum ={x.sumab}"); 
	}
	static int Main(string[] args){
		int nTerms=(int) 1e8,nThreads=1;
		foreach(var arg in args){
			var words = arg.Split(':');
			if(words[0]=="-terms") nTerms = (int)float.Parse(words[1]);
			if(words[0]=="-threads") nThreads = (int)float.Parse(words[1]);
		}
		//WriteLine($"nTerms={nTerms} nThreads={nThreads}");

		data[] x = new data[nThreads];
		for(int i=0;i<nThreads;i++){
			x[i] = new data();
			x[i].a = 1+(i*nTerms)/nThreads;
			x[i].b = 1+((i+1)*nTerms)/nThreads;
		}
		Thread[] threads = new Thread[nThreads];
		for(int i=0;i<nThreads;i++){
			threads[i] = new Thread(harm);
			threads[i].Name = $"thread number {i+1}";
			threads[i].Start(x[i]);
		}
		//WriteLine("master thread: now waiting for other threads...");
		for(int i=0;i<nThreads;i++){
			threads[i].Join();
		}
		double total=0;
		for(int i=0;i<nThreads;i++){
			total+=x[i].sumab;
		}
		WriteLine($"total = {total}");
		return 0;
	}
}
