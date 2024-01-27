extends Node2D

func _input(event: InputEvent) -> void:
	if Input.is_action_pressed("right"):
		position.x += 3
	if Input.is_action_pressed("left"):
		position.x -= 3
	if Input.is_action_pressed("up"):
		position.y -= 3
	if Input.is_action_pressed("down"):
		position.y += 3

## rot为旋转角度，调用该函数则被选择的物体设置为rot角度
func select_body_roll(rot: float) -> void:
	for child in get_children():
		if child.selected:
			child.rotation = rot
