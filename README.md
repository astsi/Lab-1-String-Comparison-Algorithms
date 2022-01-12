# Lab-1-String-Comparison-Algorithms
Algorithm design and analysis, Lab 1 – String Comparison Algorithms

Implement Rabin-Karp and Knut-Morris-Pratt algorithms for searching for strings, as well as SoundEx and Levenstein algorithms for searching for strings by similarity.
Each of them should go through the whole string, find all the occurrences of the required substring and save them in a separate file - in the case of Rabin-Karp and Knut-Morris-Pratt algorithm should return the exact matches, in the case of SoundEx words with the same code, and in the case of the Levenstein algorithm, words that are <= 3 away from the search string.

Prepare files with strings in which substrings are requested. Files should have 100, 1000, 10,000 and 100,000 words.

Support cases where the search string is contains:
- Only hex digits (16 letter alphabet)
- Entire ASCII tables (256 characters)

Test the behavior for 5, 10, 20, and 50 character substings. The string must be written in the same alphabet as the string loaded from the file.

Compare the performance of the algorithms for all the listed cases by execution time.
