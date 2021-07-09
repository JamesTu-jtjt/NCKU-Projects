#include<stdio.h>
#include<string.h>
#include<stdlib.h>

#define N 100

int addition(char str[]){
    int sum=0;
    char s[2]="+";
    char* token;
    token = strtok(str,s);
    while( token != NULL ){
        sum+=atoi(token);
        token = strtok(NULL,s);
    }
    return(sum);
}

int main() {
    char str[N];
    scanf("%s", str);
    int sum = addition(str);
    printf("%d", sum);
    return 0;
}