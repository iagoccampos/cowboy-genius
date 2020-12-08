using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question
{
	private readonly string question;
	public string QuestionText
	{
		get { return this.question; }
	}

	private string[] answers;
	public string[] Answers
	{
		get { return (string[])answers.Clone(); }
	}

	private readonly int correctAnswerIndex;

	public Question(string question, string[] answers, int correctAnswerIndex)
	{
		this.question = question;
		this.answers = answers;
		this.correctAnswerIndex = correctAnswerIndex;
	}

	public bool IsCorrectAnswer(int answerChoose)
	{
		return this.correctAnswerIndex == answerChoose;
	}
}
