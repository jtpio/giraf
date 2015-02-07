using UnityEngine;
using System.Collections;

public class AreaManager : MonoBehaviour {

	public void activateBomb (GameObject area, Transform obstruction) {
		var areaMapper = area.GetComponent<AreaMapper>();
		
		if (!areaMapper.hasObstruction) {
			var bomb = Instantiate(obstruction) as Transform;
			var obstructionScript = bomb.GetComponent<Obstruction>();
			obstructionScript.areaMapper = areaMapper;
			areaMapper.hasObstruction = true;
		}
	}
}
