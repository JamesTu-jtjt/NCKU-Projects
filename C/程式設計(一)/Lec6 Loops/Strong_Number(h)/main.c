#include <stdio.h>

int main(){
    int n, a, b, c, x;
    scanf("%d", &n);
    x=n;
    c=0;
    while (x!=0) {
        b=1;
        a = x%10;
        while (a != 0) {
            b*=a;
            a-=1;
        }
        c+=b;
        x/=10;
    }
    if (c==n){
        printf("%d is a strong number.", n);
    }
    else {
        printf("%d is not a strong number.", n);
    }
    return 0;
}
