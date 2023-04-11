using System;
using static System.Math;
using static System.Console;
using static matrix;
using static EVD;

static class main{
	static int Main(){
		int returnCode=0;
		bool test=false;
		var rnd = new Random();
		int maxInt = 5;
		int n=rnd.Next(3,maxInt);
		matrix A = new matrix(n,n);
		matrix I = matrix.id(n);
		int ran=0;
		for(int i=0;i<n;i++){
			for(int j=0;j<n;j++){
				ran=rnd.Next(0,100);
				if(i>=j){
					A[i,j]=ran;
					A[j,i]=ran;
				}
			}
		}
		A.print("A: \n");
		(matrix V,vector w)= Eigen(A);
		V.print("V: \n");
		matrix VT=V.transpose();
		matrix D=matrix.id(n);
		for(int i=0;i<n;i++)
			D[i,i]=w[i];
		D.print("D: \n");
		
		Write("Testing if V^T*A*V=D...");
		if(!D.approx(VT*A*V))
			test=true;
			
		if(test){
			returnCode++;
			Write("Test failed\n");
			test=false;
		}else Write("Test passed\n");

		Write("Testing if V*D*V^T=A...");
		if(!A.approx(V*D*VT))
			test=true;
			
		if(test){
			returnCode++;
			Write("Test failed\n");
			test=false;
		}else Write("Test passed\n");
		
		Write("Testing if V^T*V=1...");
		if(!I.approx(VT*V))
			test=true;
			
		if(test){
			returnCode++;
			Write("Test failed\n");
			test=false;
		}else Write("Test passed\n");

		Write("Testing if V*V^T=1...");
		if(!I.approx(V*VT))
			test=true;
			
		if(test){
			returnCode++;
			Write("Test failed\n");
			test=false;
		}else Write("Test passed\n");
		return returnCode;
	}
}
