using UnityEngine;

public class Health : MonoBehaviour
{
	public float maxHP = 100f;
	public float HP = 100f; 
	public float regenDelay = 0f; // in seconds
	public float regenSpeed = 0f; // hp/sec
	private float regenDelayTimer;	

	public bool isImmune = false;
	public bool isDead = false;

	private void Update()
	{
		if (regenSpeed != 0)
			Regen();
	}

	private void Regen()
	{
		if (!isDead)
		{
			if (regenDelayTimer < regenDelay)
				regenDelayTimer += Time.deltaTime;
			else
				HP = Mathf.Clamp(HP + regenSpeed * Time.deltaTime, 0, maxHP);
		}
	}

	public void Damage(float value)
	{
		if (!isImmune && !isDead)
		{
			HP = Mathf.Clamp(HP - value, 0, maxHP);
			if (HP <= 0)
				Death();
			regenDelayTimer = 0;
			//vfx?sfx?
		}
	}

	public void Death()
	{
		isDead = true;
		//vfx?sfx?
	}

	public void Heal(float value) {
		if (!isDead)
		{
			HP = Mathf.Clamp(HP + value, 0, maxHP);
			//vfx?sfx?
		}
	}

}
