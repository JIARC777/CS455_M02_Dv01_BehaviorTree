﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITask
{
	bool execute();

}
public class Selector: ITask
{
	List<ITask> children;
	public Selector(List<ITask> taskList)
	{
		children = taskList;
	}

	public  bool execute()
	{
		foreach (ITask child in children)
		{
			if (child.execute())
				return true;
		}
		return false;
	}
}

public class Sequence : ITask
{
	List<ITask> children;
	public Sequence(List<ITask> taskList)
	{
		children = taskList;
	}
	public bool execute()
	{
		foreach (ITask child in children)
		{
			if (child.execute() == false)
				return false;
		}
		return true;
	}
}

public class isDoorOpen: ITask
{
	Door door;
	public isDoorOpen(Door refDoor)
	{
		door = refDoor;
	}
	public bool execute()
	{
		Debug.Log("Checking For Open Door: " + door.isOpen);
		return door.isOpen;
	}
}
public class isDoorClosed : ITask
{
	Door door;
	public isDoorClosed(Door refDoor)
	{
		door = refDoor;
	}
	public bool execute()
	{
		Debug.Log("Checking For Closed Door: " + !door.isOpen);
		return !door.isOpen;
	}
}

public class isDoorUnlocked : ITask
{
	Door door;
	public isDoorUnlocked(Door refDoor)
	{
		door = refDoor;
	}
	public bool execute()
	{
		Debug.Log("Checking For Unlocked Door: " + !door.isLocked);
		return !door.isLocked;
	}
}

public class OpenDoor: ITask
{
	Door door;
	public OpenDoor(Door refDoor)
	{
		door = refDoor;
	}
	public bool execute()
	{
		Debug.Log("Opening Door");
		return door.Open();
	}
}

public class BargeDoor : ITask
{
	Rigidbody doorRB;

	public BargeDoor(Door refDoor)
	{
		doorRB = refDoor.GetComponent<Rigidbody>();
	}

	public bool execute()
	{
		Debug.Log("barging door");
		//mDoor.AddExplosionForce(10f, mDoor.transform.position, 5f);
		doorRB.AddForce(5f, 1f, 5f, ForceMode.VelocityChange);
		return true;
	}
}

public class MoveToTarget: ITask
{
	Vector3 location;
	public bool execute()
	{
		Debug.Log("Moving Towards Target");
		return true;
	}
}

public class MoveToDoor : ITask
{
	Vector3 location;
	public bool execute()
	{
		Debug.Log("Moving Towards Door");
		return true;
	}
}
