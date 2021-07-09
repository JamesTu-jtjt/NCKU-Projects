#include <stdio.h>
#include <stdlib.h>

struct node {
    int val;
    struct node* next;
};
//global variables
struct node* head = NULL;
struct node* tail = NULL;

void MoveToTail() {
    int l=0;
    for(struct node *p=head;p!=NULL;p=p->next){
        if(p->val>l) l=p->val;
    }
    struct node *temp=malloc(sizeof(struct node)), *d=malloc(sizeof(struct node));
    temp->val=l;
    temp->next=NULL;
    tail->next=temp;
    tail=temp;
    for(struct node *p=head;p!=NULL;p=p->next){
        if(p->next->val==l) {
            d=p->next;
            p->next=p->next->next;
            free(d);
            break;
        }
        else if(p->val==l) {
            d=head;
            head=head->next;
            free(d);
            break;
        }
    }
}

int main(void) {
    int n;
    scanf("%d", &n);
    for(int i = 1; i <= n; ++i) {
        struct node* tmp = malloc(sizeof(struct node));
        scanf("%d", &tmp->val);
        tmp->next = NULL;
        if(i == 1)
            head = tmp;
        else
            tail->next = tmp;
        tail = tmp;
    }
    MoveToTail();
    for(struct node* cur = head; cur != NULL; cur = cur->next)
        printf("%d ", cur->val);
    return 0;
}

