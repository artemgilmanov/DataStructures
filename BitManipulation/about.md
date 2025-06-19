##   The basics of bit manipulation

# Base

## Meaning of Base

Base is a carry counting system with fixed digital symbols and rules.

Each carry counting system will have a base. When the base is X, we call it base-X numeral system, which means the number on each digit will be carried over when it reaches X.

The actual value of a base-X number is determined by each digit and its location. The weight of the m-th digit counting from right to left in the integer part is X^m, and the smallest value of m is 0. The weight of the n-th digit counting from left to right in the fractional part is X^−n, and the smallest value of n is 1.

For example, `123.45` in decimal (base-10) can be written as:

123.45 = 1×10² + 2×10¹ + 3×10⁰ + 4×10⁻¹ + 5×10⁻²
`720.5` in octal (base-8) can be written as:
720.5₈ = 7×8² + 2×8¹ + 0×8⁰ + 5×8⁻¹


## Commonly used bases

In daily life, the most commonly used base system is the decimal. It has 10 digits: 0, 1, 2, 3, 4, 5, 6, 7, 8, and 9.

In computer science:
- The **binary** system is most commonly used. It has two digits: 0, and 1. 
- **Octal** (base-8) has eight digits: 0, 1, 2, 3, 4, 5, 6, and 7.
- **Hexadecimal** (base 16) has sixteen digits: 0-9 and A, B, C, D, E, F, corresponding to 10-15 in decimal respectively.

## Conversion between bases

### Non-decimal to decimal

To convert a non-decimal number to decimal, we need to add the weighted sum of each digit. For example, to convert the octal number `720.5₈` to decimal:

720.5₈ = 7×8² + 2×8¹ + 0×8⁰ + 5×8⁻¹ = 464.625


### Decimal to non-decimal

To convert a decimal number to a base-X non-decimal, we need to convert the integer part and the fractional part separately.

#### Integer part conversion
Divide the integer by X until it reaches 0, and record the remainder each time. The remainders in reverse order give the base-X representation.

Example: Convert `50` in decimal to binary:

50 / 2 = 25; remainder 0
25 / 2 = 12; remainder 1
12 / 2 = 6; remainder 0
6 / 2 = 3; remainder 0
3 / 2 = 1; remainder 1
1 / 2 = 0; remainder 1

Reading remainders in reverse: `110010₂`

#### Fractional part conversion
Multiply the fractional part by X until it becomes 0, recording the integer part each time. The integer parts in order give the base-X representation.

Example: Convert `0.6875` in decimal to binary:

0.6875 × 2 = 1.375 → 1
0.375 × 2 = 0.75 → 0
0.75 × 2 = 1.5 → 1
0.5 × 2 = 1 → 1

Result: `0.1011₂`

Note: A finite fraction in one base may become infinite in another (e.g., decimal `0.2` becomes binary `0.00110011...₂`).

### Conversion between other bases

The common practice is to convert to decimal first, then to the target base. However, some conversions can be done directly:

- Binary ↔ Octal: Group binary digits in 3s
- Binary ↔ Hexadecimal: Group binary digits in 4s

Example: Convert `101110010₂`:
- To octal: `101|110|010` → `562₈`
- To hexadecimal: `1|0111|0010` → `172₁₆`

## Representing integers in computer

# Binary in Computers

## Overview
Computers use binary, consisting of two digits: 0 and 1. A single binary digit (bit) has two possible values, and a k-digit binary number can take 2^k possible values.

## Integer Data Types
Common integer data types in computer science:

| Data Type   | Binary Digits | Possible Values |
|-------------|--------------|-----------------|
| 1-byte      | 8            | 2⁸ = 256         |
| 2-byte      | 16           | 2¹⁶ = 65,536     |
| 4-byte      | 32           | 2³² ≈ 4.3 billion|
| 8-byte      | 64           | 2⁶⁴ ≈ 1.8×10¹⁹   |

## Signed vs Unsigned Integers

### Signed Integers
- Highest bit represents sign (0 = non-negative, 1 = negative)
- Remaining bits represent magnitude
- 1-byte range: -128 to 127 (-2⁷ to 2⁷-1)

### Unsigned Integers
- All bits represent magnitude (no negative values)
- 1-byte range: 0 to 255 (0 to 2⁸-1)

### General Formulas
For k-bit integers:
- Signed range: -2^(k-1) to 2^(k-1)-1
- Unsigned range: 0 to 2^k-1

## Number Representations

### Machine Number vs Truth Value
- **Machine number**: Binary representation in computer (includes sign bit)
- **Truth value**: Actual numerical value represented

Example:
- `10001010` (machine number) = 138 (value) but represents -10 (truth value)

### Original, Inverse, and Complement Codes

#### Original Code
- Sign bit + absolute value
- Example for +10: `00001010`
- Example for -10: `10001010`
- Range for 8-bit: -127 to +127
- Problems: Dual representation of zero (±0), subtraction errors

#### Inverse Code
- Non-negatives: Same as original
- Negatives: Flip all bits except sign bit
- Example for -10: `11110101`
- Solves subtraction errors but still has ±0

#### Complement Code
- Non-negatives: Same as original
- Negatives: Inverse code + 1
- Example for -10: `11110110`
- Advantages:
  - No ±0 (`00000000` is 0, `10000000` is -128)
  - Correct subtraction
  - Additional minimum value
- Used by computers for calculations

## Why Computers Use Complement Code
1. Eliminates dual representation of zero
2. Enables correct arithmetic operations
3. Provides one extra negative number in range
4. Simplifies hardware implementation (no special cases for subtraction)

Example of 8-bit ranges:
- Original/Inverse: -127 to +127
- Complement: -128 to +127

## Concepts and properties of bitwise operators

# Overview of Bit Operations

## Introduction
Computers use binary (0 and 1) for all operations, which are implemented through bit operations. There are six fundamental bit operations:

1. AND (`&`)
2. OR (`|`)
3. XOR (`^`)
4. Negation (`~`)
5. Left Shift (`<<`)
6. Right Shift (`>>`)

Only negation is a unary operation; the others are binary.

## Basic Bitwise Operations

### AND Operation (`&`)
**Rule**: Both bits must be 1 to return 1

0 & 0 = 0
0 & 1 = 0
1 & 0 = 0
1 & 1 = 1


### OR Operation (`|`)
**Rule**: At least one bit must be 1 to return 1

0 | 0 = 0
0 | 1 = 1
1 | 0 = 1
1 | 1 = 1


### XOR Operation (`^`)
**Rule**: Bits must differ to return 1

0 ^ 0 = 0
0 ^ 1 = 1
1 ^ 0 = 1
1 ^ 1 = 0


### Negation (`~`)
**Rule**: Flip all bits

~0 = 1
~1 = 0


### Examples (8-bit signed)
- 46 (`00101110`) & 51 (`00110011`) = 34 (`00100010`)
- 46 | 51 = 63 (`00111111`)
- 46 ^ 51 = 29 (`00011101`)
- ~46 = -47 (`11010001`)
- ~51 = -52 (`11001100`)

## Shift Operations

### Left Shift (`<<`)
- Shift bits left, discarding high bits
- Low bits filled with 0s
- Arithmetic and logical shifts are identical

### Right Shift
Two types:
1. **Arithmetic Shift (`>>` in C/C++/Java)**
   - Preserves sign bit (fills with highest bit)
2. **Logical Shift (`>>>` in Java)**
   - Always fills with 0s

**Examples**:
- 29 (`00011101`) << 2 = 116 (`01110100`)
- 50 (`00110010`) >> 1 = 25 (`00011001`)
- -50 (`11001110`):
  - Arithmetic >> 2 = -13 (`11110011`)
  - Logical >> 2 = 51 (`00110011`)

**Language Differences**:
- C/C++: Signed types use arithmetic shift, unsigned use logical
- Java: `>>` is arithmetic, `>>>` is logical

## Shift Operations and Math

### Left Shift = Multiplication
- `a << k` = a × 2^k
- Example: 29 << 2 = 116 (29 × 4)
- Can implement any multiplication via shifts and adds

### Right Shift ≈ Division
- For non-negatives: `a >> k` = floor(a / 2^k)
- For negatives: Results differ (rounds toward -∞ vs 0)
  - (-50) >> 2 = -13
  - (-50) / 4 = -12

## Properties of Bitwise Operations

### Algebraic Properties
- **Idempotent**: `a & a = a`, `a | a = a`
- **Commutative**: `a OP b = b OP a` (for &, |, ^)
- **Associative**: `(a OP b) OP c = a OP (b OP c)`
- **Distributive**:
  - `(a & b) | c = (a | c) & (b | c)`
  - `(a ^ b) & c = (a & c) ^ (b & c)`

### Special Properties
- **De Morgan's Laws**:
  - `~(a & b) = (~a) | (~b)`
  - `~(a | b) = (~a) & (~b)`
- **Negation**: `-a = ~(a - 1)`
- **AND**:
  - `a & 0 = 0`
  - `a & (~a) = 0`
- **OR**: `a | (~a) = -1` (all 1s)
- **XOR**:
  - `a ^ 0 = a`
  - `a ^ a = 0`

### Advanced Techniques
- `a & (a - 1)`: Clears lowest set bit
- `a & (-a)`: Isolates lowest set bit

These properties enable efficient algorithms for many bit manipulation problems.

## Example 504. Base 7

# Method 1: Calculate the Remainder in Reverse

## Problem Description
Convert a given integer `num` to its base 7 representation, where `num` may be:
- 0
- Positive
- Negative

## Solution Approach

### Special Case
- If `num = 0`, its base 7 representation is simply `"0"`

### Positive Numbers (`num > 0`)
1. Repeatedly divide `num` by 7 until it reaches 0
2. Record the remainder at each step
3. The base 7 representation is obtained by reversing the sequence of remainders

**Example**: Convert decimal 102 to base 7

102 ÷ 7 = 14 remainder 4
14 ÷ 7 = 2 remainder 0
2 ÷ 7 = 0 remainder 2

Reverse remainders: `2`, `0`, `4` → `"204"`

### Negative Numbers (`num < 0`)
1. Convert the absolute value of `num` to base 7 using the above method
2. Add a negative sign to the result

## Implementation

1. Use an array to store remainders in forward direction
2. If original number was negative, append '-' to the array
3. Reverse the array and concatenate to form the final string

## Complexity Analysis

### Time Complexity
- O(log₇|num|) 
- We perform up to log₇|num| division operations

### Space Complexity 
- O(log₇|num|)
- Space required to store the intermediate remainders

## Edge Cases
- Handles 0 correctly
- Preserves sign for negative numbers
- Works with both small and large numbers

## Example Walkthrough

**Input**: -102  
**Steps**:
1. Take absolute value: 102
2. Convert 102 to base 7: "204"
3. Add negative sign: "-204"
**Output**: "-204"

## Example 405. Convert a Number to Hexadecimal

# Method 1: Use Complement Code for Hexadecimal Conversion

## Problem Description
Convert a given 32-bit integer `num` to its hexadecimal representation, handling both positive and negative numbers.

## Key Insight
- Uses two's complement representation for negative numbers
- Each hexadecimal digit corresponds to exactly 4 binary bits
- A 32-bit integer can be represented by 8 hexadecimal digits

## Solution Approach

### Step-by-Step Process
1. **Handle Special Case**:
   - If `num = 0`, return `"0"`

2. **Hexadecimal Mapping**:
   - Create a mapping array: `char[] map = {'0','1','2','3','4','5','6','7','8','9','a','b','c','d','e','f'}`

3. **Extract Each Nibble (4-bit group)**:
   - For each of the 8 possible nibbles (from highest to lowest):
     - Right shift by `4 × i` to bring the nibble to the least significant position
     - Mask with `0xf` (binary `1111`) to isolate the nibble
     - Map the 4-bit value to its hexadecimal character

4. **Handle Leading Zeros**:
   - Skip leading zeros in the result
   - Start concatenating from the first non-zero nibble

5. **Negative Numbers**:
   - Automatically handled by two's complement arithmetic
   - No special treatment needed beyond the standard conversion

## Implementation Example

```java
public String toHex(int num) {
    if (num == 0) return "0";
    char[] map = {'0','1','2','3','4','5','6','7','8','9','a','b','c','d','e','f'};
    StringBuilder sb = new StringBuilder();
    for (int i = 7; i >= 0; i--) {
        int nibble = (num >> (4 * i)) & 0xf;
        if (sb.length() > 0 || nibble != 0) {
            sb.append(map[nibble]);
        }
    }
    return sb.toString();
}
```
Complexity Analysis
Time Complexity
O(8) → O(1)

Always processes exactly 8 nibbles regardless of input size

Space Complexity
O(8) → O(1)

Stores up to 8 characters in the result

Key Advantages
Handles Negatives Automatically: Uses processor's native two's complement arithmetic

Efficient: Processes exactly 8 nibbles without conditionals for negative cases

No String Reversal: Processes from most significant to least significant nibble

Leading Zero Handling: Naturally skips leading zeros during concatenation

Example Walkthroughs
Positive Number (26):

Binary: 00000000 00000000 00000000 00011010
Hex: 0x1a
Process:
1. Isolate nibbles: 0, 0, 0, 0, 0, 0, 1, a
2. Skip leading zeros → "1a"

Negative Number (-1):

Binary (two's complement): 11111111 11111111 11111111 11111111
Hex: 0xffffffff
Process:
1. All nibbles are 'f'
2. Result: "ffffffff"

Zero:

Direct return: "0"

## Example 371. Sum of Two Integers

# Method 1: Bitwise Operations for Addition

## Problem Description
Implement the sum of two integers `a` and `b` without using the `+` or `-` operators.

## Key Insight
Binary addition can be decomposed into:
1. **Sum without carry** (XOR operation)
2. **Carry computation** (AND operation followed by left shift)

## Algorithm

### Step-by-Step Process
1. **Calculate sum without carry**:
   - `sum = a ^ b` (XOR operation)

2. **Calculate carry**:
   - `carry = (a & b) << 1` (AND operation + left shift)

3. **Iterate until no carry**:
   - Set `a = sum` and `b = carry`
   - Repeat until carry becomes 0

4. **Final result**:
   - When carry is 0, `sum` contains the final result

### Implementation
```python
def getSum(a: int, b: int) -> int:
    while a != 0:
        carry = (a & b) << 1  # Calculate carry
        b = a ^ b             # Calculate sum without carry
        a = carry            # Set new a as carry
    return b
```

Example Walkthrough
Example 1: 5 + 7

Initial: a=5 (0101), b=7 (0111)

1. sum = 0101 ^ 0111 = 0010 (2)
   carry = (0101 & 0111) << 1 = 0101 << 1 = 1010 (10)
   
2. a=10 (1010), b=2 (0010)
   sum = 1010 ^ 0010 = 1000 (8)
   carry = (1010 & 0010) << 1 = 0010 << 1 = 0100 (4)
   
3. a=4 (0100), b=8 (1000)
   sum = 0100 ^ 1000 = 1100 (12)
   carry = (0100 & 1000) << 1 = 0000 << 1 = 0000 (0)
   
Result: 12 (when carry becomes 0)

Example 2: -2 + 3

Initial: a=-2 (1110 in 4-bit two's complement), b=3 (0011)

1. sum = 1110 ^ 0011 = 1101 (-3)
   carry = (1110 & 0011) << 1 = 0010 << 1 = 0100 (4)
   
2. a=4 (0100), b=-3 (1101)
   sum = 0100 ^ 1101 = 1001 (-7)
   carry = (0100 & 1101) << 1 = 0100 << 1 = 1000 (-8)
   
3. a=-8 (1000), b=-7 (1001)
   sum = 1000 ^ 1001 = 0001 (1)
   carry = (1000 & 1001) << 1 = 1000 << 1 = 0000 (0)
   
Result: 1 (when carry becomes 0)

Complexity Analysis
Time Complexity
O(log max(a,b))
The number of iterations is proportional to the number of bits needed to represent the larger number, as each iteration potentially reduces the magnitude of the carry.

Space Complexity
O(1)
Uses constant extra space regardless of input size.

Key Properties
Handles Negative Numbers: Works correctly with two's complement representation

No Arithmetic Operators: Uses only bitwise operations

Efficient: Typically completes in logarithmic time relative to input size

General Solution: Works for all integer values within language limits

Edge Cases
Adding zero to a number

Adding two negative numbers

Adding numbers with opposite signs

Overflow cases (handled automatically by language's integer representation)

## Example 89. Gray Code

# Method 1: Generate Gray Code Bit by Bit

## Problem Description
Generate an n-bit Gray code sequence where:
- Two successive values differ by exactly one bit
- The sequence starts with 0
- Contains all possible 2^n numbers from 0 to 2^n - 1

## Key Insight
The n-bit Gray code can be constructed from the (n-1)-bit Gray code:
1. Prefix existing codes with 0
2. Mirror the sequence and prefix with 1

## Algorithm

### Construction Process
1. **Base Case**:
   - 1-bit Gray code: [0, 1]

2. **Recursive Step**:
   - Take the (n-1)-bit Gray code
   - Create two copies:
     - First copy: Prefix all codes with 0
     - Second copy: Reverse the order and prefix with 1
   - Concatenate these two lists

### Implementation
```python
def grayCode(n: int) -> List[int]:
    if n == 0:
        return [0]
    
    # Start with 1-bit Gray code
    result = [0, 1]
    
    for i in range(2, n+1):
        # Mirror the current code and add 2^(i-1) to each element
        mirrored = [x + (1 << (i-1)) for x in reversed(result)]
        result += mirrored
    
    return result
```

Example Walkthrough
2-bit Gray Code:

1. Start with 1-bit: [0, 1]
2. Mirror and add 2: [1+2, 0+2] = [3, 2]
3. Combine: [0, 1, 3, 2]

3-bit Gray Code:

1. Take 2-bit: [0, 1, 3, 2]
2. Mirror and add 4: [2+4, 3+4, 1+4, 0+4] = [6, 7, 5, 4]
3. Combine: [0, 1, 3, 2, 6, 7, 5, 4]

Complexity Analysis
Time Complexity
O(2^n)
We generate exactly 2^n numbers, each in constant time

Space Complexity
O(1) for auxiliary space
The output space (2^n elements) is not counted in space complexity

Only constant extra space is used beyond the result storage

Key Properties
Correctness: Guarantees exactly one bit difference between consecutive numbers

Completeness: Contains all numbers from 0 to 2^n - 1

Efficiency: Optimal time complexity as we must generate 2^n numbers

Simple Implementation: Easy to understand and implement

Mathematical Formulation
For n-bit Gray code g(n):

g(1) = [0, 1]

g(n) = [0+g(n-1)[0], ..., 0+g(n-1)[2^(n-1)-1],
1+g(n-1)[2^(n-1)-1], ..., 1+g(n-1)[0]]

Applications
Digital communications

Error correction

Rotary encoders

Solving puzzles like the Tower of Hanoi

##  State Compression via Bit Manipulation

# State Compression: Concepts and Applications

## Definition
State compression is a technique that represents multiple binary states (0/1) using a single integer, where each bit in the binary representation corresponds to one state.

### Key Characteristics:
- For `n` items with 2 states each → Total possible states: 2ⁿ
- Each state can be represented by an n-bit binary number
- Example (n=5): `01011₂` represents:
  - Item 1: Taken (1)
  - Item 2: Taken (1)
  - Item 3: Not taken (0)
  - Item 4: Taken (1)
  - Item 5: Not taken (0)

## Application Scenarios

### When to Use:
- Problems with small state spaces (typically n ≤ 20)
- Each element has exactly two possible states
- Need to efficiently represent and manipulate combinations of states

### Common Applications:
1. Subset selection problems
2. Bitmask representations
3. Graph traversal with visited states
4. Dynamic programming optimizations

## State Compression in Dynamic Programming

### Why Use State Compression DP?
- Avoids recomputation of identical states
- Reduces space complexity compared to naive approaches
- Enables efficient representation of combinatorial states

### The Three Elements:
1. **State Definition**:
   - Represent state as a bitmask integer
   - Example: `dp[mask]` where each bit represents an item's selection status

2. **State Transfer Function**:
   - Transition between states using bit operations
   - Common operations:
     ```python
     # Check if ith item is selected
     if mask & (1 << i):
     
     # Select ith item
     new_mask = mask | (1 << i)
     
     # Unselect ith item
     new_mask = mask & ~(1 << i)
     ```

3. **Base Cases**:
   - Initial state (typically `dp[0]` for no items selected)
   - Boundary conditions

### Complexity Analysis:
- Time: O(2ⁿ × f(n)) where f(n) is the cost per state transition
- Space: O(2ⁿ) for storing DP states

## Practical Example: Traveling Salesman Problem

### Problem Statement:
Find the shortest route visiting all cities exactly once and returning to the origin.

### State Compression Approach:
```python
def tsp(dist):
    n = len(dist)
    dp = [[float('inf')] * n for _ in range(1<<n)]
    dp[1][0] = 0  # Starting at city 0
    
    for mask in range(1, 1<<n):
        for u in range(n):
            if mask & (1<<u):
                for v in range(n):
                    if not mask & (1<<v):
                        new_mask = mask | (1<<v)
                        dp[new_mask][v] = min(dp[new_mask][v], dp[mask][u] + dist[u][v])
    
    return min(dp[(1<<n)-1][u] + dist[u][0] for u in range(n))
```

Optimization Techniques
Common Optimizations:
Memoization: Store computed states to avoid recomputation

Bitmask Tricks:

mask & (mask-1): Clears the lowest set bit

mask & -mask: Isolates the lowest set bit

Symmetry Reduction: Exploit symmetrical states to reduce state space

Pruning: Eliminate impossible states early

Limitations
Scalability: Becomes impractical for n > 20 (1 million states)

Readability: Bit manipulation can reduce code clarity

State Representation: Only works for binary state problems

Advanced Topics
Meet-in-the-Middle: Split state space for large n

Stochastic States: Extensions for probabilistic systems

Multi-valued States: Using multiple bits per state

##  Example 1349. Maximum Students Taking Exam

# Method 1: Dynamic Programming with State Compression

## Problem Description
Given a classroom seating arrangement (represented as a binary matrix where 1 = available seat, 0 = broken seat), determine the maximum number of students that can be seated following these rules:
1. No students can sit adjacent to each other (left/right/front/back/diagonal)
2. Students can only sit in available seats

## Solution Approach

### State Representation
- Represent each row's seating status as a bitmask (n-bit number where n = columns)
- `dp[row][mask]` = max students for first `row` rows with current row having `mask` configuration

### Key Steps
1. **Preprocess Seats**:
   - Convert each row to a bitmask (`curRow`) where 1=available seat
   
2. **DP Initialization**:
   - `dp[0][*] = 0` (no students in row 0)

3. **State Transitions**:
   For each row from 1 to m:
   - For each valid current row mask `curStatus`:
     - Must be a subset of `curRow`
     - No adjacent 1s (`curStatus & (curStatus << 1) == 0`)
     - For each valid previous row mask `prevMask`:
       - No diagonal conflicts (`curStatus & (prevMask << 1) == 0` and `curStatus & (prevMask >> 1) == 0`)
       - Update `dp[row][curStatus]` with `dp[row-1][prevMask] + popcount(curStatus)`

4. **Result Extraction**:
   - Final answer is `max(dp[m][*])`

## Implementation

```python
def maxStudents(seats):
    m, n = len(seats), len(seats[0])
    
    # Preprocess seat availability
    seat_masks = [0] * m
    for i in range(m):
        for j in range(n):
            if seats[i][j] == '.':
                seat_masks[i] |= (1 << j)
    
    # Initialize DP table
    dp = [[-1] * (1 << n) for _ in range(m+1)]
    dp[0][0] = 0
    
    for row in range(1, m+1):
        cur_row_mask = seat_masks[row-1]
        for mask in range(1 << n):
            # Check if mask is valid for current row
            if (mask & cur_row_mask) != mask:
                continue
            if mask & (mask << 1):
                continue
            # Count students in current row
            cnt = bin(mask).count('1')
            # Check all compatible previous masks
            for prev_mask in range(1 << n):
                if dp[row-1][prev_mask] == -1:
                    continue
                if (mask & (prev_mask << 1)) or (mask & (prev_mask >> 1)):
                    continue
                if dp[row][mask] < dp[row-1][prev_mask] + cnt:
                    dp[row][mask] = dp[row-1][prev_mask] + cnt
    
    return max(dp[m])
```

Complexity Analysis
Time Complexity
O(m × 2²ⁿ)

m rows × 2ⁿ masks per row × 2ⁿ checks per mask

Practical when n ≤ 8 (256 masks per row)

Space Complexity
O(m × 2ⁿ)

DP table stores m rows × 2ⁿ masks

Optimization Techniques
Precompute Valid Masks:

Generate all non-adjacent masks for each row in advance

Memoization:

Store compatible mask pairs to avoid recomputation

Bit Tricks:

Fast population count (number of set bits)

Efficient adjacency checks

Example Walkthrough
For input:

seats = [["#",".","#","#",".","#"],
         [".","#","#","#","#","."],
         ["#",".","#","#",".","#"]]

Row masks: [0b010010, 0b101101, 0b010010]

DP progression:

Row 1 valid masks: 0b000000 (0), 0b010000 (4)

Row 2 valid masks: 0b000000, 0b100001, 0b001000, etc.

Final maximum found in last row

Result: 4 students can be seated.
