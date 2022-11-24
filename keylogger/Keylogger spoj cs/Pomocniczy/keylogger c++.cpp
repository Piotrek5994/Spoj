#include <cctype>
#include <iostream>
#include <stack>
#include <string>

int main()
{
    std::ios_base::sync_with_stdio(false);

    int tests;
    std::cin >> tests;

    std::stack<char> my_stack;

    while (tests--)
    {
        std::string input, output;
        std::cin >> input;

        for (char c : input)
        {
            switch (c)
            {
            case '-':
            {
                if (!output.empty())
                    output.pop_back();

                break;
            }
            case '<':
            {
                if (!output.empty())
                {
                    my_stack.push(output.back());
                    output.pop_back();
                }

                break;
            }
            case '>':
            {
                if (!my_stack.empty())
                {
                    output.push_back(my_stack.top());
                    my_stack.pop();
                }

                break;
            }
            default:
                output.push_back(c);

            }
        }

        while (!my_stack.empty())
        {
            output.push_back(my_stack.top());
            my_stack.pop();
        }

        std::cout << output << std::endl;

    }

    return 0;
}
