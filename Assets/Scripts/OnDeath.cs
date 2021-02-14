using UnityEngine;

public class OnDeath : BarnBehaviour
{
	public virtual void Die()
	{
		// Standard implementation - overrride this for more sophisticated ways of Death :)
        DoDestroy();
	}

	protected void DoDestroy()
	{
		Destroy (gameObject);
	}
}