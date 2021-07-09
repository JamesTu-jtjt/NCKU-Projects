#include<stdio.h>

void recursive(int a, int b, int n)
{
    int xn;
    xn=a+b;
    n--;
    if(n==2) {
        printf("%d\n",xn);
        return;
    }
    else if(n<2) return;
    else{
        recursive(b,xn,n);
    }
}

int main(){
    int x1,x2,n,T;
    T=1;
    while(T==1){
        scanf("%d %d %d", &x1, &x2, &n);
        recursive(x1, x2, n);
        if(n==0) {
            T = 0;
            break;
        }
    }
    return 0;
}