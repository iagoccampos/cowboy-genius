using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public static class ExtensionMethods
{
	//Transform-------------------------------------------------------------
	//Reset transform
	public static void Reset(this Transform transform)
	{
		transform.localPosition = transform.localEulerAngles = Vector3.zero;
		transform.localScale = Vector3.one;
	}

	//Pos Constrait-------------------------------------------------------------
	//Clear Sourcers
	public static void ClearSources(this PositionConstraint posCons)
	{
		int length = posCons.sourceCount;

		for(int i = 0; i < length; i++)
		{
			posCons.RemoveSource(0);
		}
	}

	//Add Sourcer
	public static void AddTransform(this PositionConstraint posCons, Transform source, float weight = 1)
	{
		ConstraintSource constraint = new ConstraintSource();

		constraint.sourceTransform = source;
		constraint.weight = weight;

		posCons.AddSource(constraint);
	}

	//Look Constrait-------------------------------------------------------------
	//Clear Sourcers
	public static void ClearSources(this LookAtConstraint posCons)
	{
		int length = posCons.sourceCount;

		for(int i = 0; i < length; i++)
		{
			posCons.RemoveSource(0);
		}
	}

	//Add Sourcer
	public static void AddTransform(this LookAtConstraint posCons, Transform source, float weight = 1)
	{
		ConstraintSource constraint = new ConstraintSource();

		constraint.sourceTransform = source;
		constraint.weight = weight;

		posCons.AddSource(constraint);
	}

	//UI--------------------------------------------------------------------
	//Focus on a input field
	public static void Focus(this InputField inputField)
	{
		inputField.Select();
		inputField.ActivateInputField();
	}

	//Put the caret at the last position
	public static void SetCaretLastPosition(this InputField inputField)
	{
		inputField.caretPosition = inputField.text.Length;
	}

	//Hide or show an image
	public static void SetVisible(this Image image, bool visible)
	{
		if(visible)
			image.color = Color.white;
		else
			image.color = Color.clear;
	}

	//-----------------------------------------------------------------------
	public static int LastIndex(this Match match)
	{
		return match.Index + match.Length;
	}

	//Stack------------------------------------------------------------------
	public static void Shuffle<T>(this Stack<T> stack)
	{
		System.Random rnd = new System.Random();

		var values = stack.ToArray();

		if(values.Length == 0)
		{
			return;
		}

		stack.Clear();
		foreach(var value in values.OrderBy(x => rnd.Next()))
			stack.Push(value);
	}
}
