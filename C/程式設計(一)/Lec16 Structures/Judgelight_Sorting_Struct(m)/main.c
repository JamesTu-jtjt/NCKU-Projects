#include <stdio.h>
#include <stdlib.h>

struct ESPer {
    int level;
    char name[64];
};

int cmp(const void *a, const void *b) {
    return ( *(int*)a - *(int*)b );
    /* same effect as
    if( *(int*)a < *(int*)b ) return -1;
    else if( *(int*)a == *(int*)b ) return 0;
    else if( *(int*)a > *(int*)b ) return 1;
     */
}

void sort_level(struct ESPer *arr, int length) {
    qsort(arr, length, sizeof(struct ESPer),cmp);
}

int main()
{
    int n;
    struct ESPer tokiwadai[100];

    scanf("%d", &n);
    for(int i = 0; i < n; ++i) {
        scanf("%d %s", &(tokiwadai[i].level), tokiwadai[i].name);
    }

    sort_level(tokiwadai, n);

    for(int i = 0;i < n;++i) {
        printf("%d %s\n", tokiwadai[i].level, tokiwadai[i].name);
    }

    return 0;
}