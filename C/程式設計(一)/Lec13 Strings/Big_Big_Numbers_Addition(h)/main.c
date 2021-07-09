#include<stdio.h>
#include<string.h>

void add(char a[], char b[], char res[]){
    int na,nb,nr;
    char o='0';
    na=strlen(a);
    nb=strlen(b);
    int ra[na],rb[nb];
    char rres[105];
    for(int i=0; i<na;i++) ra[i]=a[na-1-i];
    for(int i=0; i<nb;i++) rb[i]=b[nb-1-i];
    if(nb==1 && na==1){
        res[0]=ra[0]+rb[0]-'0';
        if(ra[0]+rb[0]-48>57) {
            res[1] = res[0]- 10;
            res[0] = '1';
        }
    }
    else if(na>=nb) {
        for(int i=0; i<na; i++){
            if(i<=(nb-1)){
                res[na-i]=ra[i]+rb[i]-2*48+o;
                o='0';
            }
            else {
                res[na-i]=o+ra[i]-48;
                o='0';
            }
            if(res[na-i]>57) {
                res[na-i]-=10;
                o='1';
                if(i==na-1)res[0]='1';
            }
        }
        if(res[0]!='1'){
            for(int i=0;i<na;i++) res[i]=res[i+1];
            res[na]='\0';
        }
    }
    else if(na<nb) {
        for(int i=0; i<nb; i++){
            if(i<=(na-1)){
                res[nb-i]=ra[i]+rb[i]-2*48+o;
                o='0';
            }
            else {
                res[nb-i]=o+rb[i]-48;
                o='0';
            }
            if(res[nb-i]>57) {
                res[nb-i]-=10;
                o='1';
                if(i==nb-1)res[0]='1';
            }
        }
        if(res[0]!='1'){
            for(int i=0;i<nb;i++) res[i]=res[i+1];
            res[nb]='\0';
        }
    }
}

int main(){
    char a[100], b[100], res[105];
    scanf("%s %s", a, b);
    add(a, b, res);
    printf("%s", res);
    return 0;
}