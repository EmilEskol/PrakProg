using System;
using static System.Math;
using static System.Console;
using static matrix;
using static QRGS;

static class main{
	static int Main(){
		int returnCode=0;
		bool test=true;
		var rnd = new Random();
		int maxInt = 5;
		int n=rnd.Next(2,maxInt);
		int m=rnd.Next(2,maxInt);
		if(m>n){
			int placeHolder=m;
			m=n;n=placeHolder;
		}
		matrix A=new matrix(n,m);
		for(int i=0;i<n;i++)
			for(int j=0;j<m;j++)
				A[i,j]=rnd.Next(maxInt*3);
		(matrix Q, matrix R)=decomp(A);

		if(test){
			Write("Testing if R is upper triangullar...");
			for(int i=0;i<m;i++)
				for(int j=0;j<i;j++)
					if(!approx(R[i,j],0)){
						test=false;
					}
		}
		if(test)
			Write("Test passed\n");
		else{
			Write("Test failed\n");
			returnCode++;
		}
		test=true;
		
		if(test){
			Write("Testing if Q^T*Q=1...");
			matrix Test=Q.T*Q;
			for(int i=0;i<m;i++)
				for(int j=0;j<m;j++)
					if(i==j){
						if(!approx(Test[i,j],1))
							test=false;
					}
					else
						if(!approx(Test[i,j],0))
							test=false;
		}
		if(test)
			Write("Test passed\n");
		else{
			Write("Test failed\n");
			returnCode++;
		}
		test=true;

		if(test){
			Write("Testing if Q*R=A...");
			matrix Test=Q*R;
			for(int i=0;i<m;i++)
				for(int j=0;j<m;j++)
					if(!approx(Test[i,j],A[i,j]))
							test=false;
		}
		if(test)
			Write("Test passed\n");
		else{
			Write("Test failed\n");
			returnCode++;
		}
		test=true;
		
		A=new matrix(n,n);
		vector b=new vector(n);
		for(int i=0;i<n;i++){
			b[i]=rnd.Next(maxInt*3);
			for(int j=0;j<n;j++)
				A[i,j]=rnd.Next(maxInt*3);
		}
		(Q,R)=decomp(A);
		vector x=solve(Q,R,b);
		

		if(test){
			Write("Testing if A*x=b...");
		vector Test=A*x;
			for(int i=0;i<m;i++)
				if(!approx(Test[i],b[i]))
					test=false;
		}
		if(test)
			Write("Test passed\n");
		else{
			Write("Test failed\n");
			returnCode++;
		}
		test=true;
		matrix B=inverse(Q,R);

		if(test){
			Write("Testing if A*B=I...");
		matrix Test=A*B;
			for(int i=0;i<m;i++)
				for(int j=0;j<m;j++)
					if(i==j){
						if(!approx(Test[i,j],1))
							test=false;
					}
					else
						if(!approx(Test[i,j],0))
							test=false;
		}
		if(test)
			Write("Test passed\n");
		else{
			Write("Test failed\n");
			returnCode++;
		}
		test=true;
			
		return returnCode;
	}
}
