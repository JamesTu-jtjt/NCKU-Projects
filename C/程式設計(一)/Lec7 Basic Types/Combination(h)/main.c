#include<stdio.h>

int main(){
    int m,n,i;
    long long int mn,m1,n1,c;
    scanf("%d %d",&m,&n);
    m1=m;
    n1=n;
    mn=m-n;
    if(m==n) printf("%d",m/n);
    else if (n>=(m-n)) {
        for (i = (m - 1); i > n; i--) {
            m1 *= i;
        }
        for (i = (mn - 1); i > 0; i--) {
            mn *= i;
        }
        c = m1 / mn;
        printf("%llu", c);
    }
    else{
        for (i = (m - 1); i > (m-n); i--) {
            m1 *= i;
        }
        for (i = (n - 1); i > 0; i--) {
            n1 *= i;
        }
        c=m1/n1;
        printf("%llu",c);
    }
    return 0;
}