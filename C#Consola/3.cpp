#include <cmath>
#include <cstdio>
#include <vector>
#include <iostream>
#include <algorithm>
using namespace std;


int main() {
    /* Enter your code here. Read input from STDIN. Print output to STDOUT */ 
    int n;
    cin>>n;
    if ( n >= 1 && n <= 9 ){
        if ( n == 1 )
            cout<<"One";
            
        else if ( n == 2 )
            cout<<"Two";
       
            
        else if ( n == 3 )
            cout<<"Three";
      
        
        else if ( n == 4 )
            cout<<"Four";
      
            
        else if ( n == 5 )
            cout<<"One";
            
        else if ( n == 6 )
            cout<<"Five";
        
            
        else if ( n == 7 )
            cout<<"Seven";
        
        
        else if ( n == 8 )
            cout<<"Eigth";
            
        else if ( n == 9 )   
            cout<<"Nine";
        
    }
    else{
        cout<<"Greater than 9";
    }
 
   return 0;
}