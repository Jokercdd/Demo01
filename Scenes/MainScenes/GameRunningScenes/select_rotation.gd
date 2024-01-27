extends Node2D

var selected: bool = false

func _input(event: InputEvent) -> void:
	if selected:
		return
	
	if event is InputEventMouseButton:
		if event.button_index == 1:
			if event.is_pressed():
				for limb in $Goose.get_children():
					if limb.mouse_in_area:
						selected = true
						limb.selected = true
						limb.modulate = Color(1,0,0)
