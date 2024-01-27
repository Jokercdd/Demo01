extends Node2D

func _input(event: InputEvent) -> void:
	if Input.is_action_pressed("move_right"):
		position.x += 3
	if Input.is_action_pressed("move_left"):
		position.x -= 3
	if Input.is_action_pressed("move_up"):
		position.y -= 3
	if Input.is_action_pressed("move_down"):
		position.y += 3

## rot为旋转角度，调用该函数则被选择的物体设置为rot角度
func select_body_roll(rot: float) -> void:
	for child in get_children():
		if child.selected:
			child.rotation = rot
