using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    private int currentFrame = 1;
    private int currentFibonacci = 0;
    private int previousFibonacci = 1;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World!");
        Debug.Log($"Frame {currentFrame}: {currentFibonacci}");
    }

    // Update is called once per frame
    void Update()
    {
        currentFrame++;

        // Calculate the next Fibonacci number
        int nextFibonacci = currentFibonacci + previousFibonacci;

        // Check if the next Fibonacci number exceeds 1000
        if (nextFibonacci > 1000)
        {
            // Stop updating and printing once it exceeds 1000
            Destroy(this);
            return;
        }

        // Update the values for the next iteration
        previousFibonacci = currentFibonacci;
        currentFibonacci = nextFibonacci;

        // Print the current Fibonacci number
        Debug.Log($"Frame {currentFrame}: {currentFibonacci}");
    }
}
