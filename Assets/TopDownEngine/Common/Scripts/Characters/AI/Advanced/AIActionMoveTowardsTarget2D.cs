using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;

namespace MoreMountains.TopDownEngine
{
	/// <summary>
	/// Requires a CharacterMovement ability. Makes the character move up to the specified MinimumDistance in the direction of the target. 
	/// </summary>
	[AddComponentMenu("TopDown Engine/Character/AI/Actions/AIActionMoveTowardsTarget2D")]
	//[RequireComponent(typeof(CharacterMovement))]
	public class AIActionMoveTowardsTarget2D : AIAction
	{
		/// the minimum distance from the target this Character can reach.
		[Tooltip("the minimum distance from the target this Character can reach.")]
		public float MinimumDistance = 1f;

		protected CharacterMovement _characterMovement;
		protected int _numberOfJumps = 0;

		/// <summary>
		/// On init we grab our CharacterMovement ability
		/// </summary>
		public override void Initialization()
		{
			if(!ShouldInitialize) return;
			base.Initialization();
			_characterMovement = this.gameObject.GetComponentInParent<Character>()?.FindAbility<CharacterMovement>();
		}

		/// <summary>
		/// On PerformAction we move
		/// </summary>
		public override void PerformAction()
		{
			Move();
		}

		/// <summary>
		/// Moves the character towards the target if needed
		/// </summary>
		protected virtual void Move()
		{
			if (_brain.Target == null)
			{
				return;
			}
			float xdif = System.Math.Abs(this.transform.position.x - _brain.Target.position.x);
            float ydif = System.Math.Abs(this.transform.position.y - _brain.Target.position.y);
			float xgain = 1;
			float ygain = 1;
			if (xdif > ydif)
			{
				ygain = (ydif * xgain) / xdif;

			}
			else
			{
                xgain = (xdif * ygain) / ydif;
            }

            if (this.transform.position.x < _brain.Target.position.x)
			{

				_characterMovement.SetHorizontalMovement(xgain);
			}
			else
			{
				_characterMovement.SetHorizontalMovement(-xgain);
			}

			if (this.transform.position.y < _brain.Target.position.y)
			{
				_characterMovement.SetVerticalMovement(ygain);
			}
			else
			{
				_characterMovement.SetVerticalMovement(-ygain);
			}
            
			if (Mathf.Abs(this.transform.position.x - _brain.Target.position.x) < MinimumDistance)
			{
				_characterMovement.SetHorizontalMovement(0f);
			}

			if (Mathf.Abs(this.transform.position.y - _brain.Target.position.y) < MinimumDistance)
			{
				_characterMovement.SetVerticalMovement(0f);
			}
		}

		/// <summary>
		/// On exit state we stop our movement
		/// </summary>
		public override void OnExitState()
		{
			base.OnExitState();

			_characterMovement?.SetHorizontalMovement(0f);
			_characterMovement?.SetVerticalMovement(0f);
		}
	}
}