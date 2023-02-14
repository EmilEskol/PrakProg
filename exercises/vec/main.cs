using System;
using static System.Math;
using static System.Console;
using static vec;

static class main{
	static int Main(){
		int returnCode=0;
		bool test;
		var rnd=new Random();
		int n=9;
		vec[] vecs=new vec[n];
		for(int i=0;i<n;i++)
			vecs[i]=new vec(10*(rnd.NextDouble()-0.5),
				10*(rnd.NextDouble()-0.5),10*(rnd.NextDouble()-0.5));
		
		Write("Testing ToString and...\n");
		for(int i=0;i<n;i++){
			Write(vecs[i]);Write(" = ");vecs[i].print();}
		
		Write("Testing vec*c...\n");
		test=true;
		for(int i=0;i<n;i++){
			int rndInt=rnd.Next(10);
			vec v=vecs[i];
			vec u=new vec(v.x*rndInt,v.y*rndInt,v.z*rndInt);
			v=v*rndInt;
			test=test && v.approx(u);	
		}
		if(test)
			Write("passed\n");
		else
			Write("failed\n");

		Write("Testing c*vec...\n");
		test=true;
		for(int i=0;i<n;i++){
			int rndInt=rnd.Next(10);
			vec v=vecs[i];
			vec u=new vec(v.x*rndInt,v.y*rndInt,v.z*rndInt);
			v=rndInt*v;
			test=test && v.approx(u);	
		}
		if(test)
			Write("passed\n");
		else
			Write("failed\n");

		Write("Testing vec+vec...\n");
		test=true;
		for(int i=0;i<n;i++){
			vec v=vecs[i];
			vec u=new vec(rnd.Next(10),rnd.Next(10),rnd.Next(10));
			vec result=v+u;
			test=test && result.approx(new vec(v.x+u.x,v.y+u.y,v.z+u.z));	
		}
		if(test)
			Write("passed\n");
		else
			Write("failed\n");
		
		Write("Testing -vec...\n");
		test=true;
		for(int i=0;i<n;i++){
			vec v=vecs[i];
			vec result=-v;
			test=test && result.approx(new vec(-v.x,-v.y,-v.z));	
		}
		if(test)
			Write("passed\n");
		else
			Write("failed\n");
		
		Write("Testing vec-vec...\n");
		test=true;
		for(int i=0;i<n;i++){
			vec v=vecs[i];
			vec u=new vec(rnd.Next(10),rnd.Next(10),rnd.Next(10));
			vec result=v-u;
			test=test && result.approx(new vec(v.x-u.x,v.y-u.y,v.z-u.z));	
		}
		if(test)
			Write("passed\n");
		else
			Write("failed\n");

		Write("Testing vec.dot(vec)...\n");
		test=true;
		for(int i=0;i<n;i++){
			vec v=vecs[i];
			vec u=new vec(rnd.Next(10),rnd.Next(10),rnd.Next(10));
			double result=v.dot(u);
			double expResult=v.x*u.x+v.y*u.y+v.z*u.z;
			test=test && approx(result,expResult);	
		}
		if(test)
			Write("passed\n");
		else
			Write("failed\n");

		Write("Testing dot(vec,vec)...\n");
		test=true;
		for(int i=0;i<n;i++){
			vec v=vecs[i];
			vec u=new vec(rnd.Next(10),rnd.Next(10),rnd.Next(10));
			double result=dot(v,u);
			double expResult=v.x*u.x+v.y*u.y+v.z*u.z;
			test=test && approx(result,expResult);	
		}
		if(test)
			Write("passed\n");
		else
			Write("failed\n");
		
		Write("Testing norm(vec)...\n");
		test=true;
		for(int i=0;i<n;i++){
			vec v=vecs[i];
			double result=norm(v);
			double expResult=Sqrt(v.x*v.x+v.y*v.y+v.z*v.z);
			test=test && approx(result,expResult);	
		}
		if(test)
			Write("passed\n");
		else
			Write("failed\n");

		Write("Testing cross(vec,vec)...\n");
		test=true;
		for(int i=0;i<n;i++){
			vec v=vecs[i];
			vec u=new vec(10*(rnd.NextDouble()-0.5),10*(rnd.NextDouble()-0.5),
				10*(rnd.NextDouble()-0.5));
			vec result = cross(v,u);
			vec expResult=new vec(v.y*u.z-v.z*u.y,v.z*u.x-v.x*u.z,v.x*u.y-v.y*u.x);
			test=test && result.approx(expResult);	
		}
		if(test)
			Write("passed\n");
		else
			Write("failed\n");

		Write("Testing dot(vec1,cross(vec1,vec2))...\n");
		test=true;
		for(int i=0;i<n;i++){
			vec v=vecs[i];
			vec u=new vec(10*(rnd.NextDouble()-0.5),10*(rnd.NextDouble()-0.5),
				10*(rnd.NextDouble()-0.5));
			double result = dot(v,cross(v,u));
			test=test && approx(result,0);	
		}
		if(test)
			Write("passed\n");
		else
			Write("failed\n");
			
		if(returnCode==0){Write("all tests passed\n");}
		
		else{Write($"{returnCode} test Failed \n");}

		return returnCode;
	}
	public static bool approx(double a, double b, double acc=1e-9, double eps=1e-9){
		if(Abs(b-a) < acc) return true;
		else if(Abs(b-a) < Max(Abs(a),Abs(b))*eps) return true;
		else return false;
	}
}
