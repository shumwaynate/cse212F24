using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        var unique = new HashSet<string>(words.Length); //create string to hold a set of sets given that are unique to be checked against
        var pairs = new HashSet<string>(words.Length); //create string to hold the sets of matched sets

        for (int i = 0; i < words.Length; ++i) {//run through each of the "words" given
            string letter1 = words[i][0].ToString(); //get the first letter of the word we are on
            string letter2 = words[i][1].ToString(); //gets second letter of word we are on
            string pair = letter1 + letter2; //gets the 'word' we are on for quicker calls
            string pairReverse = letter2 + letter1; //gets the opposite of 'word' we are on

            if(unique.Contains(pairReverse)){ //If the unique list has a word that is the opposite of one we are on
                pairs.Add($"{pair}&{pairReverse}"); //add the paire to the return unique pairs.
            }else{//If the word doesn'e have a matching pair
                unique.Add(pair);//add word to unique to be compared to next words
            }
        }
        
        return pairs.ToArray(); //return the pair hashset just as a normal array of strings as requested
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename)) //go line by line
        {
            var fields = line.Split(","); //split items into list of string


            if(degrees.ContainsKey(fields[3])){//checks if the column 4 degree type is in dictionary already
                var currentCount = degrees[fields[3]]; //gets the amount of degree counts in dictionary
                degrees[fields[3]] = currentCount + 1; //add one to the amount of people with degree
            }else{ //if not in dictionary
                degrees.Add(fields[3], 1); //add the degree into the dictionary
            }
        }

        return degrees; //return dictionary
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // Remove spaces and convert to lowercase
        var cleanedWord1 = word1.Replace(" ", "").ToLower();
        var cleanedWord2 = word2.Replace(" ", "").ToLower();

        // Anagrams must have the same length
        if (cleanedWord1.Length != cleanedWord2.Length)
            return false;

        // Sort characters of both words
        var sortedWord1 = cleanedWord1.OrderBy(c => c);
        var sortedWord2 = cleanedWord2.OrderBy(c => c);

        // Compare sorted characters
        bool areAnagrams = sortedWord1.SequenceEqual(sortedWord2);
        return areAnagrams;
    }


    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.
        return [];
    }
}