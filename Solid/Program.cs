

using Solid.Abstractions;
using Solid.Implementations;

//IGame game = new GuessGame(new RandomDigitGenerator());
IGame game = new GuessGame(new RandomDigitSquareGenerator());

game.Play();