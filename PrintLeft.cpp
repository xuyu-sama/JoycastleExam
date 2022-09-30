#include<iostream>
#include<vector>
using namespace std;

struct Node {
    char data;
    struct Node* left, *right;
};
int deepth;
Node* addNewNode(char data) {
    Node* newNode = new Node;
    newNode->data = data;
    newNode->left = newNode->right = NULL;
    return newNode;
}
void BFS(Node* root,vector<vector<Node*>> &v,int deep) {
    if (root == NULL)
        return;
    v[deep].emplace_back(root);
    //cout << "BFS新增" << deep << "层元素：" << root->data << endl;
    deep++;
    BFS(root->left, v, deep);
    BFS(root->right, v, deep);
}
int getDeepth(Node* root) {
    if (root == NULL) {
        return 0;
    }
    int left = getDeepth(root->left);
    int right = getDeepth(root->right);
    return max(left+1,right+1);
}
int main() {
    Node* root = addNewNode('A');
    root->left = addNewNode('B');
    root->right = addNewNode('C');
    root->left->left = addNewNode('D');
    root->right->left = addNewNode('E');
    root->right->right = addNewNode('F');
    root->right->left->right = addNewNode('G');
    deepth = getDeepth(root);
    vector<vector<Node*>> vec(deepth, vector<Node*>());
    BFS(root, vec,0);
    //for (int i = 0; i < deepth; i++) {
    //    for (int j = 0; j < vec[i].size(); j++) {
    //        cout << vec[i][j]->data << " ";
    //    }
    //    cout << endl;
    //}
    for (int i = 0; i < deepth; i++) {
        cout << vec[i][0]->data<<" ";
    }
    return 0;
}