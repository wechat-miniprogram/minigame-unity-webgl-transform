import { JsBehaviour } from './Base/base.mjs';
import { JSGameManager } from './JSGameManager.mjs';
class JSBallBehaviour extends JsBehaviour {
    OnTriggerEnter(trigger) {
        if (trigger == JSGameManager.instance._mb.PrescoreTrigger) {
            this.prescore = true;
        }
        if (trigger == JSGameManager.instance._mb.ScoredTrigger && this.prescore) {
            console.log("得分");
        }
    }
}
export { JSBallBehaviour };
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoiSlNCYWxsQmVoYXZpb3VyLm1qcyIsInNvdXJjZVJvb3QiOiIiLCJzb3VyY2VzIjpbIi4uLy4uLy4uLy4uL0Jhc2tldGJhbGxEZW1vL1R5cGVzY3JpcHRzL0pTQmFsbEJlaGF2aW91ci5tdHMiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IkFBQUEsT0FBTyxFQUFFLFdBQVcsRUFBRSxNQUFNLGlCQUFpQixDQUFBO0FBQzdDLE9BQU8sRUFBRSxhQUFhLEVBQUUsTUFBTSxxQkFBcUIsQ0FBQztBQUVwRCxNQUFNLGVBQWdCLFNBQVEsV0FBK0I7SUFHekQsY0FBYyxDQUFDLE9BQWdDO1FBQzNDLElBQUksT0FBTyxJQUFJLGFBQWEsQ0FBQyxRQUFRLENBQUMsR0FBRyxDQUFDLGVBQWUsRUFBRTtZQUN2RCxJQUFJLENBQUMsUUFBUSxHQUFHLElBQUksQ0FBQztTQUN4QjtRQUNELElBQUksT0FBTyxJQUFJLGFBQWEsQ0FBQyxRQUFRLENBQUMsR0FBRyxDQUFDLGFBQWEsSUFBSSxJQUFJLENBQUMsUUFBUSxFQUFFO1lBQ3RFLE9BQU8sQ0FBQyxHQUFHLENBQUMsSUFBSSxDQUFDLENBQUE7U0FDcEI7SUFDTCxDQUFDO0NBQ0o7QUFFRCxPQUFPLEVBQUUsZUFBZSxFQUFFLENBQUEifQ==