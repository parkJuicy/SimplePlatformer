#### 충돌감지방식

1. 원하는 만큼 이동한 뒤 충돌검사를 해서 뒤로 밀려나게 하는방법
   - 2개이상의 방향이 겹쳐지는 경우 버그가 생길 수 있음
2. **이동 전 앞으로 갈 방향에 충돌체가 있는경우 겹쳐지지 않도록 델타값만큼 조금만 이동하는 방법 - 내가 힘을 주고있는 힘과 방향에 따라 이동거리를 계산**
   - 겹쳐지는 경우에 대한 건 생각하지 않기 때문에 정적인 지형에서만 충돌처리가 가능함
   - 현서님이 피드백한 움직이는 플랫폼에 대한 충돌감지는 이 방법만으로는 해결 할 수 없음
   - 일단 당장 생각나는 방법은 없어서 구현하지 못하고 다른 기능을 우선 구현할 생각임



#### CharacterController2D => CharacterRigidbody , CharacterMovement로 기능 분리

- PlayerInput 에서 플레이어가 키입력
- CharacterMovement에게 이동명령
- CharacterMovement는 충돌을 담당하는 CharacterRigidbody에게 겹쳐지지 않는 선에서 이동 가능한 거리를 받아와서 이동시킴



#### 점프

- 점프가 부드럽지 않게 작동되는 부분이 있어 https://github.com/vrompasa/2d-platformer-character-controller 에서 참고해서 작업함



AinmationController

- CharacterMovement와 CharacterRigidbody를 참조해서 현재 상태에서 사용할 애니메이션을 보여줌

