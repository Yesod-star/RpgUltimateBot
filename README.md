<h1>RpgUltimateBot</h1>

<h2>RpgUltimateBot is a bot developed in C# using DsharpPLus and Lavalink to improve your tabletop sessions</h2>

<p>
The bot has two main functions, roll dice and play music to create an ambient atmosphere. The purpose of rolling dice is to make the checks on the table available for
everyone to see.In the case of the DiceHidden command, for the GM to have a way to roll dice in secret and see the result. For the music functions, now you can play whatever 
audio, theme or song you want to any circumstance you want.
</p>

<h2>How to make the bot work:</h2>
<ol>
  <li>Enter https://discord.com/developers/applications and create a bot</li>
  <li>Give the bot autorization to join channels, play audio, text in channel and see messages.</li>
  <li>Generate a Token for the Bot and copy it in a safe location.</li>
  <li>Create a URL and add the bot to the server you want.</li>
  <li>Copy the repository.</li>
  <li>Add your token to appsettings.json.</li>
  <li>Open your cmd and go to the directory you added the project.</li>
  <li>Open the AmbientBot and run the following command <b>java -jar Lavalink.jar</b>.</li>
</ol>

<h2>List of commands:</h2>
<ol>
  <li>Dice: Send the command with the amount of dices to show a result, the dices must follow the format of XdY+Z, with X,Y and Z being integers.</li>
  <li>DiceHidden: It follows the same rules of the Dice command but send the result to the private chat of the person who send it.</li>
  <li>Join: Makes the bot join the voice channel the command was used.(It must be used on the chat of a Voice Channel)</li>
  <li>Leave: Makes the bot leave the voice channel it is.</li>
  <li>Play: Play the audio of a video that was chosen.</li>
  <li>Pause: Pause the audio that was playing in the bot.</li>
  <li>Resume: Resume the audio after it was paused.</li>
  <li>Volume: Set the volume based on an integer number it was typed.</li>  
</ol>
