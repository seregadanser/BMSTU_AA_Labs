#include "Gen.hpp"
#include <random>


using namespace std;

char ala[26] = {'q','w','e','r','t','y','u','i','o','p','a','s','d','f','g','h','j','k','l','z','x','c','v','b','n','m'};

void gen_case(char* m, int n) {


	m[n] = '\0';
	for(int i = 0; i<n;i++)
	{
		m[i]= ala[rand()%26];
	}
}
